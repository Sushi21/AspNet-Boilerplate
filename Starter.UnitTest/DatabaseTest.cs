using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starter.Persistence.Context;
using Microsoft.EntityFrameworkCore;

public class DatabaseTest
{
  private DataContext instance;
  protected DataContext dataContext
  {
    get
    {
      if (instance != null)
      {
        return instance;
      }
      else
      {
        instance = GetDatabaseContext();
        return instance;
      }
    }
  }

  private DataContext GetDatabaseContext()
  {
    var options = new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

    var databaseContext = new DataContext(options);
    databaseContext.Database.EnsureCreated();

    return databaseContext;
  }
}
