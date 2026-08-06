using Core.MediatOR.Contracts;
using Microsoft.AspNetCore.Mvc;
using Starbucks.Application.Coffees.Commands;
using Starbucks.Application.Coffees.DTOs;

namespace Starbucks.Api.Controllers
{
    [ApiController]
    [Route("api/coffees")]
    public class CoffeeController (IMediator mediator): Controller
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost]
        public async Task<IActionResult> Create(CoffeeCreateRequest request,CancellationToken cancellationToken) 
        {
            var id = await _mediator.Send(new CoffeeCreate.Command { Coffee = request }, cancellationToken);
            
            return Created($"api/coffees/{id}",id);
        }
    }
}
