using Core.Mappy.Interfaces;
using Core.MediatOR.Contracts;
using FluentValidation;
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

        public class Handler(StarbucksDbContext dbContext,IMapper mapper, IValidator<Command> validator) : IRequestHandler<Command, Guid>
        {
            private readonly StarbucksDbContext _dbContext = dbContext;
            private readonly IMapper _mapper = mapper;
            private readonly IValidator<Command> _validator = validator;

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                await _validator.ValidateAndThrowAsync(request, cancellationToken);

                var coffee = _mapper.Map<Coffee>(request);
                _dbContext.Coffees.Add(coffee);
                await dbContext.SaveChangesAsync(cancellationToken);
                
                return coffee.Id;
            }
        }

        public class CommandValidation : AbstractValidator<Command> 
        {
            public CommandValidation()
            {
                RuleFor(x=> x.Coffee).SetValidator(new RequestValidator());        
            }

        }

        public class RequestValidator : AbstractValidator<CoffeeCreateRequest> 
        {
            public RequestValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
                RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
                RuleFor(x=> x.CategoryId).NotEmpty().WithMessage("Category is required");

            }
        }
    }
}
