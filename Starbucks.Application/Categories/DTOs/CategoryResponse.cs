using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Categories.DTOs
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }
        public required string NameTest { get; set; }
        public string? Description { get; set; }
    }
}
