using Starter.Application.Features.UserFeatures.CreateUser;
using Starter.Application.Features.UserFeatures.GetAllUser;
using Starter.Application.Features.UserFeatures.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Starter.WebAPI.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
  private readonly IMediator mediator;

  public UsersController(IMediator mediator)
  {
    this.mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<GetAllUserResponse>> GetAll(CancellationToken cancellationToken)
  {
    var response = await mediator.Send(new GetAllUserRequest(), cancellationToken);
    return Ok(response);
  }

  [HttpGet]
  [Route("{id:guid}")]
  public async Task<ActionResult<GetUserResponse>> Get(Guid id, CancellationToken cancellationToken)
  {
    var response = await mediator.Send(new GetUserRequest(id), cancellationToken);
    return Ok(response);
  }

  [HttpPost]
  public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request,
      CancellationToken cancellationToken)
  {
    var response = await mediator.Send(request, cancellationToken);
    return Ok(response);
  }
}