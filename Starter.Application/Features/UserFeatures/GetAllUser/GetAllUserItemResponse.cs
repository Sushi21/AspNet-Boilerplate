using Starter.Domain.Entities;

namespace Starter.Application.Features.UserFeatures.GetAllUser;

public sealed record GetAllUserItemResponse
{
  public Guid Id { get; set; }
  public string Email { get; set; }
  public string Name { get; set; }

  public GetAllUserItemResponse(User user)
  {
    this.Id = user.Id;
    this.Email = user.Email;
    this.Name = user.Name;
  }
}