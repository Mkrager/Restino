using Restino.Api;
using Serilog;

//TODO: Добавити усі логування де треба в Application layer
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Restino API starting");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, LoggerConfiguration) => LoggerConfiguration
.WriteTo.Console()
.ReadFrom.Configuration(context.Configuration)
.ReadFrom.Services(services)
.Enrich.FromLogContext(),
true
);

var app = builder
    .ConfigureServiec()
    .ConfigurePipeline();

app.UseSerilogRequestLogging();

app.Run();
public partial class Program { }

