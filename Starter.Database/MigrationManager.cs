using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Starter.Persistence;

public static class MigrationManager
{
  public static void MigrateDatabase(IServiceScopeFactory serviceScopeFactory)
  {
    using (var scope = serviceScopeFactory.CreateScope())
    {
      try
      {
        var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        migrationService.ListMigrations();
        migrationService.MigrateUp();
      }
      catch
      {
        throw new Exception("Something went wrong migrating the database");
      }
    }
  }
}