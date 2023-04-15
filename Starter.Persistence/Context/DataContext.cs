using Starter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Starter.Persistence.Context;

public class DataContext : DbContext
{
  public DbSet<User> Users { get; set; }

  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {
  }
}