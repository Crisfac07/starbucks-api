using Core.MediatOR.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Core.MediatOR
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
        {
            var handleType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(),typeof(TResponse));
            
            dynamic handler = _serviceProvider.GetRequiredService(handleType);
            if (handler is null) {
                throw new InvalidOperationException("The handler was not found for the objetc" +  request.GetType().Name);
            }

            return await handler.Handle((dynamic)request, cancellationToken);

        }
    }
}
