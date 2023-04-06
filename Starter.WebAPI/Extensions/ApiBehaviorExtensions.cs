using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Starter.WebAPI.Extensions;

public static class ApiBehaviorExtensions
{
  public static void ConfigureApiBehavior(this IServiceCollection services)
  {
    services.Configure<ApiBehaviorOptions>(options =>
    {
      options.SuppressModelStateInvalidFilter = true;
    });
  }
}