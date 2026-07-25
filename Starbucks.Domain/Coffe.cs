using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Domain
{
    public class Coffe
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? Image { get; set; }

        public required Category Category { get; set; }
    }
}
