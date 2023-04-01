using Starter.Application.Repositories;
using Starter.Domain.Entities;
using MediatR;

namespace Starter.Application.Features.UserFeatures.CreateUser;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
  private readonly IUnitOfWork unitOfWork;
  private readonly IUserRepository userRepository;

  public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
  {
    this.unitOfWork = unitOfWork;
    this.userRepository = userRepository;
  }

  public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
  {
    var user = new User() { Name = request.Name, Email = request.Email };

    userRepository.Create(user);
    await unitOfWork.Save(cancellationToken);

    return new CreateUserResponse(user);
  }
}