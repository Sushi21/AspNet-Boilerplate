using MediatR;

namespace Starter.Application.Features.UserFeatures.GetAllUser;

public sealed record GetAllUserRequest : IRequest<GetAllUserResponse>;