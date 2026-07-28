using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Starbucks.Api.Resources;
using Starbucks.Domain;
using Starbucks.Persistence;

namespace Starbucks.Api.Extensions
{
    public static class DatabaseInitializer
    {
        public static async Task ApplyMigration
            (
                this WebApplication webApplication,
                IWebHostEnvironment environment
            )
        {

            using (var scope = webApplication.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = service.GetRequiredService<StarbucksDbContext>();
                    await context.Database.MigrateAsync();
                    await DataSeed(context, environment);

                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<ILoggerFactory>();
                    logger.LogError(ex, "Error during the migration");
                }
            }
        }


        public static async Task DataSeed(StarbucksDbContext dbContext, IWebHostEnvironment environment)
        {
            if (dbContext.Coffees.Any()) return;
            if (environment is null) throw new Exception("The environment was not loaded");

            var path = Path.Combine(environment.ContentRootPath, "Resources/coffee.json");
            var coffeeDataText = await File.ReadAllTextAsync(path);

            var data = JsonConvert.DeserializeObject<List<CoffeeJson>>(coffeeDataText)
                ?? Enumerable.Empty<CoffeeJson>();

            var coffeeMaster = new List<Coffee>();
            var ingredientMaster = new List<Ingredient>();
            var random = new Random();

            foreach (var coffeeElement in data)
            {
                var ingredientLocal = new List<Ingredient>();
                foreach (var ingredient in coffeeElement.Ingredients)
                {
                    var existingIngredient = ingredientMaster
                        .FirstOrDefault(
                            i => 
                            string.Equals(
                                i.Name, 
                                ingredient, 
                                StringComparison.CurrentCultureIgnoreCase
                                ));
                    if (existingIngredient is null)
                    {
                        existingIngredient = new Ingredient
                        {
                            Id = Guid.NewGuid(),
                            Name = ingredient
                        };
                        ingredientMaster.Add(existingIngredient);
                    }
                    ingredientLocal.Add(existingIngredient);
                }

                var newCoffee = new Coffee
                { 
                    Name = coffeeElement.Title!,
                    Description = coffeeElement.Description,
                    Image = coffeeElement.Image,
                    CategoryId = coffeeElement.Category,
                    Price = RandomPrice(random, 2, 15),
                    Ingredients = ingredientLocal
                };

                coffeeMaster.Add(newCoffee);
            }

            await dbContext.Ingredients.AddRangeAsync(ingredientMaster);
            await dbContext.Coffees.AddRangeAsync(coffeeMaster);
            await dbContext.SaveChangesAsync();


        }

        public static decimal RandomPrice(Random random, double min, double max)
        {
           return Convert.ToDecimal(Math.Round(random.NextDouble() * Math.Abs(max-min) + min, 2));
        }
    }
}
