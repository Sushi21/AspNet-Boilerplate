using Starter.Domain.Entities;

namespace Starter.Application.Features.UserFeatures.GetUser;

public class GetUserResponse
{
  public Guid Id { get; set; }
  public string Email { get; set; }
  public string Name { get; set; }

  public GetUserResponse(User user)
  {
    this.Id = user.Id;
    this.Email = user.Email;
    this.Name = user.Name;
  }
}