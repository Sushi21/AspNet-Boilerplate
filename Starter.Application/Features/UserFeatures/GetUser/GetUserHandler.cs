using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starter.Application.Repositories;
using MediatR;

namespace Starter.Application.Features.UserFeatures.GetUser;

public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
  private readonly IUserRepository userRepository;

  public GetUserHandler(IUserRepository userRepository)
  {
    this.userRepository = userRepository;
  }

  public Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
  {
    var user = userRepository.Get(request.Id);
    return Task.FromResult(new GetUserResponse(user));
  }
}