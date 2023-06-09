﻿using Starter.Application.Repositories;
using Starter.Persistence.Context;
using Starter.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Starter.Persistence;

public static class ServiceExtensions
{
  public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("PostgreSQL");
    services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));

    services.AddScoped<IUserRepository, UserRepository>();
  }
}