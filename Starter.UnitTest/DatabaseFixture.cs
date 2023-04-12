using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Starter.Persistence.Context;

namespace Starter.UnitTest;

public class DatabaseFixture : IDisposable
{
  private readonly DataContext context;

  public string Connection { get; }

  public string TemplateDatabaseName { get; }

  public DatabaseFixture()
  {
    var id = Guid.NewGuid().ToString().Replace("-", "");

    TemplateDatabaseName = $"my_db_tmpl_{id}";

    Connection = $"Server=localhost;Username=postgres;Password=postgres;Port=54292;";

    this.CreateDatabase();

    Connection += $"Database={TemplateDatabaseName};";

    context = new DataContext(new DbContextOptionsBuilder<DataContext>()
        .UseNpgsql(Connection).Options);

    using (var scope = this.CreateServiceProvider().CreateScope())
    {
      var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
      runner.ListMigrations();
      runner.MigrateUp();
    }

    context.Database.CloseConnection();
  }

  private void CreateDatabase()
  {
    using (var tmplConnection = new NpgsqlConnection(Connection))
    using (var cmd = new NpgsqlCommand($"CREATE DATABASE {TemplateDatabaseName}", tmplConnection))
    {
      tmplConnection.Open();
      cmd.ExecuteNonQuery();
    }
  }

  private ServiceProvider CreateServiceProvider()
  {
    return new ServiceCollection()
        .AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddPostgres11_0()
            .WithGlobalConnectionString(Connection)
            .ScanIn(Assembly.LoadFrom(".\\Starter.Database.dll")).For.Migrations())
        .BuildServiceProvider();
  }

  public void Dispose()
  {
    context.Database.EnsureDeleted();
  }
}