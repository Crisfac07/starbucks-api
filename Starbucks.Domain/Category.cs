using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Starbucks.Domain
{
    public class Category
    {
        [SetsRequiredMembers]
        private Category(int id, string name) => (Id, Name) = (id, name);
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Coffee>? Coffees { get; set; }

        public static Category Create(int id) 
        {
            var categoryName = (CategoryEnum)id;
            string categoryNameString = categoryName.ToString();
            return new Category(id, categoryNameString);
        }
    }
}
