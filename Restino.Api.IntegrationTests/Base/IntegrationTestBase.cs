using Restino.Api.IntegrationTests.Base;

public class IntegrationTestBase : IAsyncLifetime
{
    protected readonly CustomIdentityWebApplicationFactory<Program> _factory;
    protected HttpClient _client;

    public IntegrationTestBase()
    {
        _factory = new CustomIdentityWebApplicationFactory<Program>();
        _client = _factory.GetAnonymousClient();
    }
    public async Task InitializeAsync()
    {
        await _factory.ResetDatabaseAsync();
    }

    public Task DisposeAsync() => Task.CompletedTask;
}
