using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppCore(this IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();
            return services;
        }
    }
}
