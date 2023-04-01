using Starter.Domain.Entities;

namespace Starter.Application.Features.UserFeatures.CreateUser;

public sealed record CreateUserResponse
{
  public Guid Id { get; set; }
  public string Email { get; set; }
  public string Name { get; set; }

  public CreateUserResponse(User user)
  {
    this.Id = user.Id;
    this.Email = user.Email;
    this.Name = user.Name;
  }
}