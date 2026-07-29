using Core.MediatOR.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Scrutor;

namespace Core.MediatOR
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatOR
            (
                this IServiceCollection services,
                params Assembly[] assemblies 
            )
        {
            services.AddScoped<IMediator, Mediator>();

            services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );

            return services;
        }
    }
}
