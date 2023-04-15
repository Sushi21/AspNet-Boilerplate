using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Starter.Database;

namespace Starter.Persistence;

public static class MigrationManager
{
  public static void MigrateDatabase(IServiceScopeFactory serviceScopeFactory)
  {
    using (var scope = serviceScopeFactory.CreateScope())
    {
      try
      {
        IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

        var connectionString = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("PostgreSQL"));

        if (!DatabaseCreator.IsDatabaseExist(connectionString, connectionString?.Database))
        {
          DatabaseCreator.CreateDatabase(connectionString, connectionString?.Database);
        }

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