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
  public ActionResult<GetAllUserResponse> GetAll()
  {
    var response = mediator.Send(new GetAllUserRequest());
    return Ok(response);
  }

  [HttpGet]
  [Route("{id:guid}")]
  public ActionResult<GetUserResponse> Get(Guid id)
  {
    var response = mediator.Send(new GetUserRequest(id));
    return Ok(response);
  }

  [HttpPost]
  public ActionResult<CreateUserResponse> Create(CreateUserRequest request)
  {
    var response = mediator.Send(request);
    return Ok(response);
  }
}