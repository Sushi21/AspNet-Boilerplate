using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecks.System;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Starter.WebAPI
{
  public static class ServiceExtensions
  {
    public static void ConfigureHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddHealthChecks()
        .AddDiskStorageHealthCheck(delegate (DiskStorageOptions diskStorageOptions)
        {
          diskStorageOptions.AddDrive(@"C:\", 500000);
        }, "My Drive", HealthStatus.Degraded)
        .AddSqlite(
          configuration.GetConnectionString("Sqlite"),
          "select name from sqlite_master where type='table'",
          "My Database");

      services.AddHealthChecksUI(setupSettings: setup =>
      {
        setup.SetEvaluationTimeInSeconds(5);
        setup.MaximumHistoryEntriesPerEndpoint(50);
        setup.AddHealthCheckEndpoint("My App", "https://localhost:7292/health");
      })
      .AddSqliteStorage(configuration.GetConnectionString("Sqlite"));
    }
  }
}