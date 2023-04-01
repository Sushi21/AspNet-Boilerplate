using Starter.Domain.Entities;

namespace Starter.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
  Task<bool> IsEmailAlreadyExist(string email, CancellationToken cancellationToken);
  Task<User> GetByEmail(string email, CancellationToken cancellationToken);
}