using Starter.Application.Repositories;
using MediatR;

namespace Starter.Application.Features.UserFeatures.GetAllUser;

public sealed class GetAllUserHandler : IRequestHandler<GetAllUserRequest, GetAllUserResponse>
{
    private readonly IUserRepository userRepository;

    public GetAllUserHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    
    public async Task<GetAllUserResponse> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAll(cancellationToken);
        return new GetAllUserResponse(users);
    }
}