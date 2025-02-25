using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Moq;
using Respawn;
using Respawn.Graph;
using Restino.Persistence;
using System.Security.Claims;

namespace Restino.Api.IntegrationTests.Base
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private Respawner _respawner;
        private readonly IConfiguration _configuration;

        public CustomWebApplicationFactory()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        }

        public void SetUpHttpContext(string userId, string userName)
        {
            var userClaims = new List<Claim>
        {
            new Claim("uid", userId),
            new Claim(ClaimTypes.Name, userName)
        };

            var identity = new ClaimsIdentity(userClaims, "Test");
            var user = new ClaimsPrincipal(identity);

            var httpContext = new DefaultHttpContext { User = user };

            _httpContextAccessorMock.Setup(h => h.HttpContext).Returns(httpContext);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(async services =>
            {
                services.RemoveAll(typeof(DbContextOptions<RestinoDbContext>));

                services.AddDbContext<RestinoDbContext>(options =>
                {
                    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RestinoTestDb;Trusted_Connection=True;MultipleActiveResultSets=true");
                });

                services.AddSingleton<IHttpContextAccessor>(_httpContextAccessorMock.Object);

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<RestinoDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    try
                    {
                        context.Database.EnsureDeleted();
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
            SetUpHttpContext("0ee44930-75f2-4ffe-bf30-bce82bf45ddd", "Smaga");
            var client = CreateClient();
            var fakeJwtToken = JwtTokenGenerator.GenerateFakeJwt(_configuration);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", fakeJwtToken);
            return client;
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }
    }
}
