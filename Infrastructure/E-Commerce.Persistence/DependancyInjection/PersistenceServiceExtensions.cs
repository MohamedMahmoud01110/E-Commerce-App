using E_Commerce.Persistence.Context;
using E_Commerce.Persistence.DbInitializers;
using E_Commerce.Persistence.Repositories;
using E_Commerce.Persistence.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
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
            services.AddSingleton<IConnectionMultiplexer>(cfg =>
            {
                return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")!);
            });
            services.AddDbContext<ApplicationDbContext>(options =>
            {

                var connection = configuration.GetConnectionString("SQLConnection");
                options.UseSqlServer(connection);

            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ICashService, CashService>();
            services.AddScoped<IDbInitializer, DbInitializer>();
            return services;
        }
    }
}
