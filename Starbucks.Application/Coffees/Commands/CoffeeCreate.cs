using Core.Mappy.Interfaces;
using Core.MediatOR.Contracts;
using Starbucks.Application.Coffees.DTOs;
using Starbucks.Domain;
using Starbucks.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Coffees.Commands
{
    public class CoffeeCreate
    {
        public class Command : IRequest<Guid> 
        { 
                public required CoffeeCreateRequest Coffee { get; set; }
        }

        public class Handler(StarbucksDbContext dbContext,IMapper mapper) : IRequestHandler<Command, Guid>
        {
            private readonly StarbucksDbContext _dbContext = dbContext;
            private readonly IMapper _mapper = mapper;

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var coffee = _mapper.Map<Coffee>(request);
                _dbContext.Coffees.Add(coffee);
                await dbContext.SaveChangesAsync(cancellationToken);
                
                return coffee.Id;
            }
        }
    }
}
