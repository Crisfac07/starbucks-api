using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Domain
{
    public class Ingredient : BaseEntity
    {
        public required string Name { get; set; }
    }
}
