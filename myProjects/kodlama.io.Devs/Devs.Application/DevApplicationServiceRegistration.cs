using Devs.Application.Features.PrgrammingLangues.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application
{
    public static class DevApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ProgrammingLanguageBusinessRules>();

            return services;
        }

    }
}
