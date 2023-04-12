using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Starter.Persistence.Context;

namespace Starter.UnitTest;

public abstract class DatabaseTestCase : IDisposable
{
  public DataContext Context { get; }

  protected DatabaseTestCase(DatabaseFixture databaseFixture)
  {
    var id = Guid.NewGuid().ToString().Replace("-", "");

    var databaseName = $"my_db_test_{id}";

    using (var tmplConnection = new NpgsqlConnection(databaseFixture.Connection))
    using (var cmd = new NpgsqlCommand($"CREATE DATABASE {databaseName} WITH TEMPLATE {databaseFixture.TemplateDatabaseName}", tmplConnection))
    {
      tmplConnection.Open();
      cmd.ExecuteNonQuery();
    }

    Context = new DataContext(new DbContextOptionsBuilder<DataContext>()
      .UseNpgsql($"Server=localhost;Database={databaseName};Username=postgres;Password=postgres;Port=54292;")
      .Options);
  }

  public void Dispose()
  {
    Context.Database.EnsureDeleted();
  }
}