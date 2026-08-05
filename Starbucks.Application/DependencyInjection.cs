using Core.Mappy.Extensions;
using Core.MediatOR;
using Core.MediatOR.Contracts;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Starbucks.Application.Abstractions;
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
