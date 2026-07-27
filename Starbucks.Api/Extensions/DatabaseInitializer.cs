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


        public static async Task DataSeed(StarbucksDbContext dbContext, IWebHostEnvironment environment) {
            if (dbContext.Coffees.Any()) return;
            if (environment is null) throw new Exception("The environment was not loaded");
            
            var path = Path.Combine(environment.ContentRootPath, "Resources/coffe.json");
            var coffeeDataText = await File.ReadAllTextAsync(path);

            var data = JsonConvert.DeserializeObject<List<CoffeeJson>>(coffeeDataText)
                ?? Enumerable.Empty<CoffeeJson>();

            var coffees = data.Select(json => new Coffee
            {
                Id = json.CoffeeId,
                Name = json.Title!,
                Description = json.Description,
                Price = 10,
                CategoryId = json.Category,
                Image = json.Image
            }).ToArray();

            await dbContext.Coffees.AddRangeAsync(coffees);
            await dbContext.SaveChangesAsync();

        }
    }
}
