using Core.Mappy.Interfaces;
using Starbucks.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Coffees.DTOs
{
    public class CoffeeMappingProfile : IMappingProfile
    {
        public void Configure(IMapper mapper)
        {
            mapper.CreateMap<CoffeeCreateRequest, Coffee>();
        }
    }
}
