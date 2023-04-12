using Starter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Starter.Persistence.Context;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
}