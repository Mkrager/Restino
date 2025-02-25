using Restino.App.Contracts;
using Restino.App.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString
    ("RestinoConnectionString") ?? throw new InvalidOperationException("Connection string 'RestinoDb' not found.");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri("https://localhost:7288/")
});
builder.Services.AddSingleton<JwtHelper>();

builder.Services.AddHttpContextAccessor();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddRazorPages();

builder.Services.AddScoped<IAccommodationDataService, AccommodationDataService>();
builder.Services.AddScoped<ICategoryDataService, CategoriesDataService>();
builder.Services.AddScoped<IReservationDataService, ReservationDataService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserDataService, UserDataService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();
