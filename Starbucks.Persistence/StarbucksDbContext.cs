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
        public required DbSet<Coffe> Coffes { get; set; }
        public required DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Coffes)
                .WithOne(co => co.Category)
                .HasForeignKey(co => co.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                ;
        }
    }
}
