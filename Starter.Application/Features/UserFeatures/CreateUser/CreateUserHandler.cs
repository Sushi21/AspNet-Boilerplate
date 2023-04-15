using Starter.Application.Repositories;
using Starter.Domain.Entities;
using MediatR;

namespace Starter.Application.Features.UserFeatures.CreateUser;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
  private readonly IUserRepository userRepository;

  public CreateUserHandler(IUserRepository userRepository)
  {
    this.userRepository = userRepository;
  }

  public Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
  {
    var user = new User() { Name = request.Name, Email = request.Email };

    userRepository.Create(user);

    return Task.FromResult(new CreateUserResponse(user));
  }
}