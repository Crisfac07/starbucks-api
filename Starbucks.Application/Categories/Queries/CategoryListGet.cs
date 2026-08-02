using Core.Mappy.Interfaces;
using Core.MediatOR.Contracts;
using Microsoft.EntityFrameworkCore;
using Starbucks.Application.Categories.DTOs;
using Starbucks.Domain;
using Starbucks.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Categories.Queries
{
    public class CategoryListGet
    {
        public class Query : IRequest<List<CategoryResponse>> { }

        public class Handler (StarbucksDbContext dbContext, IMapper mapper) : IRequestHandler<Query, List<CategoryResponse>>
        {
            private readonly StarbucksDbContext _dbContext = dbContext;
            private readonly IMapper _mapper = mapper;
            public async Task<List<CategoryResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var categories = await _dbContext.Categories.ToListAsync(); 
                return _mapper.Map<List<CategoryResponse>>(categories);
            }
        }
    }
}
