using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Starter.Database;

public static class ServiceExtensions
{
  public static void ConfigurationDatabaseMigration(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddPostgres11_0()
            .WithGlobalConnectionString(configuration.GetConnectionString("PostgreSQL"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
  }
}
