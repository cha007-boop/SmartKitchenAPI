using KitchenLib.Interfaces;
using KitchenLib.Models;

namespace KitchenLib.Services;

public sealed class IngredientClassifier : IIngredientClassifier
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientClassifier(IIngredientRepository ingredientRepository)
    {
        ArgumentNullException.ThrowIfNull(ingredientRepository);

        _ingredientRepository = ingredientRepository;
    }

    public async Task<Ingredient?> ClassifyAsync(ProductInfo productInfo)
    {
        ArgumentNullException.ThrowIfNull(productInfo);

        List<Ingredient> repositoryIngredients =
            (await _ingredientRepository.GetAllAsync()).ToList();

        List<string> productValues = [];

        if (!string.IsNullOrWhiteSpace(productInfo.Name))
        {
            productValues.Add(productInfo.Name);
        }

        if (!string.IsNullOrWhiteSpace(productInfo.Categories))
        {
            productValues.AddRange(
                productInfo.Categories.Split(
                    ',',
                    StringSplitOptions.RemoveEmptyEntries |
                    StringSplitOptions.TrimEntries));
        }

        foreach (string productValue in productValues)
        {
            string normalizedProductValue = NormalizeName(productValue);

            if (normalizedProductValue.Length == 0)
            {
                continue;
            }

            Ingredient? matchingIngredient = repositoryIngredients
                .FirstOrDefault(repositoryIngredient =>
                    AreEquivalent(
                        normalizedProductValue,
                        NormalizeName(repositoryIngredient.Name)));

            if (matchingIngredient is not null)
            {
                return matchingIngredient;
            }
        }

        return null;
    }

    private static bool AreEquivalent(string first, string second)
    {
        if (first.Equals(second, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        // Supports both singular-to-plural and plural-to-singular matching.
        return Singularize(first).Equals(
            Singularize(second),
            StringComparison.OrdinalIgnoreCase);
    }

    private static string NormalizeName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        string normalizedValue = value.Trim();

        // Removes OpenFoodFacts prefixes such as "en:".
        int separatorIndex = normalizedValue.IndexOf(':');

        if (separatorIndex >= 0)
        {
            normalizedValue = normalizedValue[(separatorIndex + 1)..];
        }

        var characters = new List<char>(normalizedValue.Length);
        bool previousCharacterWasWhitespace = false;

        foreach (char character in normalizedValue)
        {
            if (char.IsLetterOrDigit(character))
            {
                characters.Add(char.ToLowerInvariant(character));
                previousCharacterWasWhitespace = false;
            }
            else if (!previousCharacterWasWhitespace)
            {
                characters.Add(' ');
                previousCharacterWasWhitespace = true;
            }
        }

        return new string(characters.ToArray()).Trim();
    }

    private static string Singularize(string value)
    {
        if (value.Length == 0)
        {
            return value;
        }

        // tomatoes -> tomato
        if (value.EndsWith("oes", StringComparison.Ordinal))
        {
            return value[..^2];
        }

        // berries -> berry
        if (value.EndsWith("ies", StringComparison.Ordinal) &&
            value.Length > 3)
        {
            return $"{value[..^3]}y";
        }

        // boxes -> box, churches -> church, dishes -> dish
        if (value.EndsWith("xes", StringComparison.Ordinal) ||
            value.EndsWith("ches", StringComparison.Ordinal) ||
            value.EndsWith("shes", StringComparison.Ordinal) ||
            value.EndsWith("zes", StringComparison.Ordinal))
        {
            return value[..^2];
        }

        // Prevent incorrect conversions such as:
        // glass -> glass, status -> status, analysis -> analysis
        if (value.EndsWith("ss", StringComparison.Ordinal) ||
            value.EndsWith("us", StringComparison.Ordinal) ||
            value.EndsWith("is", StringComparison.Ordinal) ||
            value.EndsWith("se", StringComparison.Ordinal))
        {
            return value;
        }

        // apples -> apple, milks -> milk
        if (value.EndsWith('s'))
        {
            return value[..^1];
        }

        return value;
    }
}