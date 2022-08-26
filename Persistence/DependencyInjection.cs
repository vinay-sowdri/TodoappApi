using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using Persistence.Repository;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase(configuration.GetConnectionString("DemoDb")));
            services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
            services.AddScoped<IUnitofWork, UnitOfWork > ();
            return services;
            
        }
    }
}
