using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Application.Abstractions.Repositories;
using Ticketing.Persistence.Context;
using Ticketing.Persistence.Repositories;

namespace Ticketing.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketingDbContext>(options =>
               options.UseNpgsql(
                   configuration.GetConnectionString("TicketingConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddStackExchangeRedisCache(redisOptions =>
            {
                string? connection = configuration?.GetConnectionString("CacheSettings:RedisCache");

                redisOptions.Configuration = connection;
            });

            // Dist cache registration
            services.Add(ServiceDescriptor.Singleton<ICartRepository, CartRepository>());

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRowRepository, RowRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVenueRepository, VenueRepository>();

            return services;
        }
    }
}
