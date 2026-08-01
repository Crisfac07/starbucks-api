using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Coffees.DTOs
{
    public class CoffeeCreateRequest
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
    }
}
