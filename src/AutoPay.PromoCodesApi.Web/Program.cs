var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
var microsoftLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<AutoPay.PromoCodesApi.Web.Program>();

// Configure Web Behavior
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddHealthChecks();

builder.Services.AddFastEndpoints()
  .SwaggerDocument(o =>
  {
    o.MaxEndpointVersion = 1;
    o.ShortSchemaNames = true;
    o.DocumentSettings = s =>
    {
      s.DocumentName = "Release 1.0";
      s.Title = "AutoPay PromoCodes API";
      s.Version = "v1.0";
    };
  });

ConfigureMediatR();

builder.Services.AddCoreServices(microsoftLogger);
builder.Services.AddInfrastructureServices(builder.Configuration, microsoftLogger, builder.Environment.IsDevelopment());

if (builder.Environment.IsDevelopment())
{
    AddShowAllServicesSupport();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
}
else
{
    app.UseDefaultExceptionHandler(); // from FastEndpoints
    app.UseHsts();
}

app.UseFastEndpoints(c =>
  {
    c.Versioning.Prefix = "v";
    c.Versioning.PrependToRoute = true;
  }).UseSwaggerGen(); // Includes AddFileServer and static files middleware

app.MapHealthChecks("health");

app.UseHttpsRedirection();

SeedDatabase(app);

app.Run();

static void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
        context.Database.EnsureCreated();
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<AutoPay.PromoCodesApi.Web.Program>>();
        logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
}

void ConfigureMediatR()
{
    var mediatRAssemblies = new[]
    {
        Assembly.GetAssembly(typeof(PromoCode)), // CoreTests
        Assembly.GetAssembly(typeof(CreatePromoCodeCommand)) // UseCases
    };
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));
    builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
}

void AddShowAllServicesSupport()
{
    // add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
    builder.Services.Configure<ServiceConfig>(config =>
    {
        config.Services = new List<ServiceDescriptor>(builder.Services);

        // optional - default path to view services is /listallservices - recommended to choose your own path
        config.Path = "/listservices";
    });
}

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
namespace AutoPay.PromoCodesApi.Web
{
  public partial class Program
  {
  }
}
