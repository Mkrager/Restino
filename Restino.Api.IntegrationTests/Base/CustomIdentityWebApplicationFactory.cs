using Restino.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Respawn;
using Respawn.Graph;
using Microsoft.Extensions.Configuration;

namespace Restino.Api.IntegrationTests.Base
{
    public class CustomIdentityWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private Respawner _respawner;
        private readonly IConfiguration _configuration;
        public CustomIdentityWebApplicationFactory()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(async services =>
            {
                services.RemoveAll(typeof(DbContextOptions<RestinoIdentityDbContext>));

                services.AddDbContext<RestinoIdentityDbContext>(options =>
                {
                    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RestinoIdentityTestDb;Trusted_Connection=True;MultipleActiveResultSets=true");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<RestinoIdentityDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    try
                    {
                        context.Database.EnsureCreated();

                        var connection = context.Database.GetDbConnection();
                        await connection.OpenAsync();
                        _respawner = await Respawner.CreateAsync(connection, new RespawnerOptions
                        {
                            TablesToIgnore = new Table[] { "__EFMigrationsHistory" },
                            WithReseed = true
                        });
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the database. Error: {ex.Message}");
                    }
                }
            });
        }

        public HttpClient GetAuthenticatedClient()
        {
            var client = CreateClient();
            var fakeJwtToken = JwtTokenGenerator.GenerateFakeJwt(_configuration);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", fakeJwtToken);
            return client;
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }
        public async Task ResetDatabaseAsync()
        {
            using var scope = Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<RestinoIdentityDbContext>();

            var connection = context.Database.GetDbConnection();
            await connection.OpenAsync();
            await _respawner.ResetAsync(connection);
        }

    }
}
