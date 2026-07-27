using Microsoft.EntityFrameworkCore;
using Starbucks.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Persistence
{
    public class StarbucksDbContext(DbContextOptions options) : DbContext (options)
    {
        public required DbSet<Category> Categories { get; set; }
        public required DbSet<Coffee> Coffees { get; set; }
        public required DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Coffees)
                .WithOne(co => co.Category)
                .HasForeignKey(co => co.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                ;

            modelBuilder.Entity<Coffee>().Property(c => c.Price).HasPrecision(10, 2);

            modelBuilder.Entity<Coffee>()
                .HasMany(c => c.Ingredients)
                .WithMany(i => i.Coffees)
                .UsingEntity<CoffeeIngredient>(

                j => j.HasOne(ci => ci.Ingredient)
                    .WithMany(i => i.CoffeeIngredients)
                    .HasForeignKey(ci => ci.IngredientId),

                j => j.HasOne(ci => ci.Coffee)
                    .WithMany(c => c.CoffeeIngredients)
                    .HasForeignKey(ci => ci.CoffeeId),

                    j =>
                    {
                        j.HasKey(t => new { t.IngredientId, t.CoffeeId });
                    }
                );

            modelBuilder.Entity<Category>().HasData(GetCategories());
        }

        public IEnumerable<Category> GetCategories()
        {
           return Enum.GetValues<CategoryEnum>().Select(p => Category.Create((int)p));
        }
    }
}
