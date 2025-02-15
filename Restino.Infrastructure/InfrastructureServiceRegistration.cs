using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restino.Application.Contracts.Infrastructure;
using Restino.Infrastructure.Repositories;

namespace Restino.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrustructureServices(this
            IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

    }
}
