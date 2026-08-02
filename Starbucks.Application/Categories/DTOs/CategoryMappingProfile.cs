using Core.Mappy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Starbucks.Domain;

namespace Starbucks.Application.Categories.DTOs
{
    public class CategoryMappingProfile : IMappingProfile
    {
        public void Configure(IMapper mapper)
        {
            mapper.CreateMap<Category, CategoryResponse>(
                cfg => {
                    cfg.Map(dest => dest.CategoryId, src => src.Id);
                    cfg.Map(dest => dest.NameTest, dest=> dest.Name);
                }
                );
        }
    }
}
