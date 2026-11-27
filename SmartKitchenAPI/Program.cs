using KitchenLib.Interfaces;
using KitchenLib.Repositories;
using KitchenLib.Services;
using Microsoft.OpenApi;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter(
            namingPolicy: null,
            allowIntegerValues: false));
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .WithMethods("GET", "POST", "PUT", "DELETE")
                  .AllowAnyHeader();
        });
});

builder.Services.AddScoped<IGroceryService, GroceryService>();
builder.Services.AddScoped<IGroceryRepository>(serviceProvider =>
{
    IConfiguration configuration =
        serviceProvider.GetRequiredService<IConfiguration>();

    string connectionString =
        configuration.GetConnectionString("SmartKitchen")
        ?? throw new InvalidOperationException(
            "Connection string 'SmartKitchen' was not found.");

    return new GroceryRepository(connectionString);
});
builder.Services.AddScoped<IIngredientClassifier, IngredientClassifier>();
builder.Services.AddHttpClient<IProductInfoProvider, OpenFoodFactsService>(
    (serviceProvider, httpClient) =>
    {
        IConfiguration configuration =
            serviceProvider.GetRequiredService<IConfiguration>();

        string baseAddress =
            configuration["ProductInfoApi:BaseAddress"]
            ?? throw new InvalidOperationException(
                "Product info API base address was not configured.");

        httpClient.BaseAddress = new Uri(baseAddress);
    });
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");


app.UseAuthorization();

app.MapControllers();

app.Run();
