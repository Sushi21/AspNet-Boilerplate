using System.Reflection;
using Starter.Application.Common.Behaviors;
using Starter.Application.Features.UserFeatures.CreateUser;
using Starter.Application.Features.UserFeatures.GetAllUser;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Starter.Application;

public static class ServiceExtensions
{
  public static void ConfigureApplication(this IServiceCollection services)
  {
    services.AddMediatR(Assembly.GetExecutingAssembly());
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    services.RegisterRequestHandler<CreateUserHandler, CreateUserRequest, CreateUserResponse>();
    services.RegisterRequestHandler<GetAllUserHandler, GetAllUserRequest, GetAllUserResponse>();
  }
}