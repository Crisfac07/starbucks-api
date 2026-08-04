using System;
using System.Collections.Generic;
using System.Text;

namespace Core.MediatOR.Contracts
{
    public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();
    public interface IPipelineBehavior<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
    }
}
