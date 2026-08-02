using Core.MediatOR.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Starbucks.Application.Categories.DTOs;
using Starbucks.Domain;
using Starbucks.Persistence;
using static Starbucks.Application.Categories.Queries.CategoryListGet;

namespace Starbucks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<List<CategoryResponse>> Get(CancellationToken cancellationToken) 
        {
            var query = new Query();
            return await _mediator.Send(query, cancellationToken);
        }

    }
}
