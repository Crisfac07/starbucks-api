using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Domain
{
    public class Coffee : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? Image { get; set; }
        public  Category? Category { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; } = [];
        public ICollection<CoffeeIngredient>? CoffeeIngredients { get; set; } = [];
    }
}
