using KitchenLib.Interfaces;
using KitchenLib.Models;
using KitchenLib.Services;
using Microsoft.AspNetCore.Mvc;
using SmartKitchenAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartKitchenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private readonly IGroceryService _groceryService;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IGroceryRepository _groceryRepository;

        public GroceriesController(IGroceryService groceryService, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IGroceryRepository groceryRepository)
        {
            _groceryService = groceryService;
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
            _groceryRepository = groceryRepository;
        }

        // GET: api/<GroceriesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Grocery>> Get()
        {
            var groceries = _groceryService.GetAllAsync().Result.ToList();
            if (groceries.Count == 0)
            {
                return NotFound();
            }
            return Ok(groceries);
        }

        // Get api/<GroceriesController>/ingredients
        [HttpGet("ingredients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Ingredient>> GetIngredients()
        {
            var ingredients = _ingredientRepository.GetAllAsync().Result.ToList();
            if (ingredients.Count == 0)
            {
                return NotFound();
            }
            return Ok(ingredients);
        }

        // Get api/<GroceriesController>/ingredients/{id}
        [HttpGet("ingredients/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Ingredient> GetIngredient(int id)
        {
            var ingredient = _ingredientRepository.GetByIdAsync(id).Result;
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        // Get api/<GroceriesController>/recipes
        [HttpGet("recipes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Recipe>> GetRecipes()
        {
            var recipes = _recipeRepository.GetAllAsync().Result.ToList();
            if (recipes.Count == 0)
            {
                return NotFound();
            }
            return Ok(recipes);
        }

        // Get api/<GroceriesController>/recipes/{id}
        [HttpGet("recipes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Recipe> GetRecipe(int id)
        {
            var recipe = _recipeRepository.GetByIdAsync(id).Result;
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        // GET api/<GroceriesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Grocery> Get(int id)
        {
            var grocery = _groceryService.GetByIdAsync(id).Result;
            if (grocery == null)
            {
                return NotFound();
            }
            return Ok(grocery);
        }

        // POST api/<GroceriesController/scan>
        [HttpPost("scan")]
        public ActionResult<Grocery> Post([FromBody] ScanRequestDTO scanRequestDto)
        {
            var grocery = _groceryService.ProcessScanAsync(scanRequestDto.Barcode, scanRequestDto.Mode).Result;
            if (grocery == null)
            {
                return NotFound();
            }
            return Ok(grocery);
        }

        // POST api/<GroceriesController/Manuel
        [HttpPost("Manuel")]
        public async Task<ActionResult<Grocery>> ManuelPost([FromBody] ManualGroceryRequestDTO request)
        {
            var grocery = await _groceryService.ManuelAddAsync(request.Name, request.Ingredient, request.Quantity);
            if (grocery == null)
            {
                return NotFound();
            }
            return Ok(grocery);
        }

        // PUT api/<GroceriesController>/5
        [HttpPut("{id}")]
        public async  Task<ActionResult<Grocery>> Put(int id, [FromBody] GroceryDTO groceryDTO)
        {
            try
            {
                Grocery? grocery = await _groceryService.UpdateAsync(id, new Grocery
                {
                    Id = id,
                    Name = groceryDTO.Name,
                    Barcode = groceryDTO.Barcode,
                    Quantity = groceryDTO.Quantity,
                    Ingredient = groceryDTO.Ingredient
                });
                if (grocery == null)
                {
                    return NotFound();
                }
                return Ok(grocery);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<GroceriesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Grocery> Delete(int id)
        {
            Grocery? grocery = _groceryRepository.DeleteAsync(id).Result;
            if (grocery == null)
            {
                return NotFound();
            }
            return Ok(grocery);
        }

        //// PUT api/<GroceriesController>/5/add
        //[HttpPut("{id}/add")]
        //public ActionResult<Grocery> AddQuantity(int id)
        //{
        //    Grocery? grocery = _groceryService.AddQuantity(id).Result;
        //    if (grocery == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(grocery);
        //}
    }
}
