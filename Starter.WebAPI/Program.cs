using Starter.Application;
using Starter.Persistence;
using Starter.WebAPI.Extensions;
using Starter.Database;
using Starter.WebAPI.AppExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureHealthChecks(builder.Configuration);
builder.Services.ConfigureApplication();
builder.Services.ConfigurationDatabaseMigration(builder.Configuration);
builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMiniProfiler(options => options.RouteBasePath = "/profiler").AddEntityFramework();

var app = builder.Build();

if (builder.Configuration.GetValue<bool>("IsHealthCheckOn"))
{
  app.UseHealthChecks();
}

app.UseSwagger();
app.MigrateDatabase();
app.UseMiniProfiler();
app.UseSwaggerUI();
app.UseErrorHandler();
app.UseCors();
app.MapControllers();
app.Run();
