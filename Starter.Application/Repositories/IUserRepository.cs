using Starter.Domain.Entities;

namespace Starter.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
  bool IsEmailAlreadyExist(string email);
  User GetByEmail(string email);
}