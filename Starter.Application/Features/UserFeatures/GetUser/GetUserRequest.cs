using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Starter.Application.Features.UserFeatures.GetUser;

public sealed class GetUserRequest : IRequest<GetUserResponse>
{
    public Guid Id { get; set; }

    public GetUserRequest(Guid id)
    {
        this.Id = id;
    }
}