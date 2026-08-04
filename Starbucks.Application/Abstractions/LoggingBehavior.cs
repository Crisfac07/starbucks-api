using Core.MediatOR.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Abstractions
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation(
                "Starting operation {RequestName}",
                typeof(TRequest).Name
                );

            var response = await next();
            _logger.LogInformation(
                "Ending operation {RequestName}",
                typeof(TRequest).Name
                );


            return response;
        }
    }
}
