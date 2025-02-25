using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restino.Application.Contracts.Persistance;
using Restino.Persistence.Repositories;

namespace Restino.Persistence
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this
            IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestinoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString
            ("RestinoConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepositrory<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            return services;
        }
    }
}
