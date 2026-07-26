using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Domain
{
    public class Ingredient : BaseEntity
    {
        public required string Name { get; set; }
        public ICollection<Coffee>? Coffees { get; set; } = [];
        public ICollection<CoffeeIngredient>? CoffeeIngredients { get; set; } = [];
    }
}
