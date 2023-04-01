using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;

namespace Starter.Application.Common.Behaviors;

public class LoggingDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
  private readonly ILogger<TRequest> logger;

  private readonly IRequestHandler<TRequest, TResponse> decorated;

  public LoggingDecorator(ILogger<TRequest> logger, IRequestHandler<TRequest, TResponse> decorated)
  {
    this.logger = logger;
    this.decorated = decorated;
  }

  Task<TResponse> IRequestHandler<TRequest, TResponse>.Handle(TRequest request, CancellationToken cancellationToken)
  {
    logger.LogDebug($"Request <{typeof(TRequest)}> called, <{Newtonsoft.Json.JsonConvert.SerializeObject(request)}>.");

    using (MiniProfiler.Current.Step($"Request <{typeof(TRequest)}> called"))
    {
      return decorated.Handle(request, cancellationToken);
    }
  }
}