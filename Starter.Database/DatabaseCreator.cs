using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Starter.Database;

public static class DatabaseCreator
{
  public static bool IsDatabaseExist(NpgsqlConnectionStringBuilder? connectionStringBuilder, string? databaseName)
  {
    if (databaseName == null || connectionStringBuilder == null)
    {
      throw new Exception("No valid connection string was provided in the configuration.");
    }

    connectionStringBuilder.Database = "template1";

    using (var tmplConnection = new NpgsqlConnection(connectionStringBuilder.ToString()))
    using (var cmd = new NpgsqlCommand($"SELECT 1 FROM pg_database WHERE datname='{databaseName}'", tmplConnection))
    {
      tmplConnection.Open();

      var isDatabaseExist = cmd.ExecuteScalar() != null;
      return isDatabaseExist;
    }
  }

  public static void CreateDatabase(NpgsqlConnectionStringBuilder? connectionStringBuilder, string? databaseName)
  {
    if (databaseName == null || connectionStringBuilder == null)
    {
      throw new Exception("No valid connection string was provided in the configuration.");
    }

    using (var tmplConnection = new NpgsqlConnection(connectionStringBuilder.ToString()))
    using (var cmd = new NpgsqlCommand($"CREATE DATABASE \"{databaseName}\"", tmplConnection))
    {
      tmplConnection.Open();
      cmd.ExecuteNonQuery();
    }

  }
}