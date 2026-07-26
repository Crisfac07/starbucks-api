using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Domain
{
    public class CoffeeIngredient
    {
        public Guid CoffeeId { get; set; }
        public Guid IngredientId { get; set; }

        public Coffee? Coffee { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
