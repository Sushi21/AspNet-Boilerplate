using Starter.Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Starter.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
  private readonly IEnumerable<IValidator<TRequest>> validators;

  public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
  {
    this.validators = validators;
  }

  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    if (!validators.Any()) return await next();

    var context = new ValidationContext<TRequest>(request);

    var errors = validators
        .Select(async x => await x.ValidateAsync(context))
        .SelectMany(x => x.Result.Errors)
        .Where(x => x != null)
        .Select(x => x.ErrorMessage)
        .Distinct()
        .ToArray();

    if (errors.Any())
      throw new BadRequestException(errors);

    return await next();
  }
}