using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecks.System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Starter.WebAPI.Extensions;

public static class HealthChecksExtensions
{
  public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
  {
    if (configuration.GetValue<bool>("IsHealthCheckOn"))
    {
      services.AddHealthChecks()
        .AddDiskStorageHealthCheck(delegate (DiskStorageOptions diskStorageOptions)
        {
          diskStorageOptions.AddDrive(@"C:\", 5000);
        }, "My Drive", HealthStatus.Degraded)
        .AddNpgSql(
          configuration.GetConnectionString("PostgreSQL"),
          "SELECT 1",
          null,
          "My Database");

      services.AddHealthChecksUI(setupSettings: setup =>
      {
        setup.SetEvaluationTimeInSeconds(5);
        setup.MaximumHistoryEntriesPerEndpoint(50);
        setup.AddHealthCheckEndpoint("My App", "https://localhost:7292/health");
      })
      .AddPostgreSqlStorage(configuration.GetConnectionString("PostgreSQL"));
    }
  }

  public static void UseHealthChecks(this IApplicationBuilder builder)
  {
    builder.UseHealthChecks(path: "/health", new HealthCheckOptions()
    {
      Predicate = _ => true,
      ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

    builder.UseHealthChecksUI();
  }
}