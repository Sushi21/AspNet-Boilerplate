using Starter.Application.Repositories;
using FluentValidation;

namespace Starter.Application.Features.UserFeatures.CreateUser;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator(IUserRepository userRepository)
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.Email).MustAsync(async (email, cancellation) => 
        {
           return ! await userRepository.IsEmailAlreadyExist(email, cancellation);
           
        })
        .WithErrorCode("AlreadyExists")
        .WithMessage("A user with the provided email already exist");;
    }
}