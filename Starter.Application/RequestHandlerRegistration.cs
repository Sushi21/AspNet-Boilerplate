using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starter.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Starter.Application;

public static class RequestHandlerRegistration
{
  public static IServiceCollection RegisterRequestHandler<TRequestHandler, TRequest, TResponse>(
  this IServiceCollection services)
  where TRequest : IRequest<TResponse>
  where TRequestHandler : class, IRequestHandler<TRequest, TResponse>
  {

    services.AddTransient<TRequestHandler>();

    services.AddTransient<IRequestHandler<TRequest, TResponse>>(x =>
        new LoggingDecorator<TRequest, TResponse>(x.GetService<ILogger<TRequest>>(), x.GetService<TRequestHandler>()));

    return services;
  }
}