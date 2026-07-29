using Core.MediatOR.Contracts;
using Microsoft.EntityFrameworkCore;
using Starbucks.Domain;
using Starbucks.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Categories.Queries
{
    public class CategoryListGet
    {
        public class Query : IRequest<List<Category>> { }

        public class Handler (StarbucksDbContext dbContext) : IRequestHandler<Query, List<Category>>
        {
            private readonly StarbucksDbContext _dbContext = dbContext;
            public async Task<List<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Categories.ToListAsync(); 
            }
        }
    }
}
