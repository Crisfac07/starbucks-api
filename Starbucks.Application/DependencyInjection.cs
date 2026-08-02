using Core.Mappy.Extensions;
using Core.MediatOR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication( this IServiceCollection services) 
        {
            services.AddMediatOR(typeof(DependencyInjection).Assembly);
            services.AddMapper();
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        
        }
    }
}
