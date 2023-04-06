using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starter.Persistence;

namespace Starter.WebAPI.AppExtensions;

public static class DatabaseMigrator
{
  public static void MigrateDatabase(this WebApplication app)
  {
    MigrationManager.MigrateDatabase(app.Services.GetService<IServiceScopeFactory>());
  }
}
