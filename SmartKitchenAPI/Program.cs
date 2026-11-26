using KitchenLib.Interfaces;
using KitchenLib.Services;
using KitchenLib.Repositories;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
builder.Services.AddScoped<IProductInfoProvider, OpenFoodFactsService>();


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
