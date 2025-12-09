using E_Commerce.Persistence.Context;
using E_Commerce.Persistence.DbInitializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.DependancyInjection
{
    public static class PersistenceServiceExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {

                var connection = configuration.GetConnectionString("SQLConnection");
                options.UseSqlServer(connection);

            });
            services.AddScoped<IDbInitializer, DbInitializer>();
            return services;
        }
    }
}
