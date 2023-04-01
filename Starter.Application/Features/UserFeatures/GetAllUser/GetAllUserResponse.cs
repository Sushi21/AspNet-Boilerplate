using Starter.Application.Features.UserFeatures.GetUser;
using Starter.Domain.Entities;

namespace Starter.Application.Features.UserFeatures.GetAllUser;

public sealed class GetAllUserResponse
{
  public IReadOnlyList<GetUserResponse> Data { get; set; }

  public GetAllUserResponse(List<User> users)
  {
    this.Data = users.Select(u => new GetUserResponse(u)).ToList();
  }
}