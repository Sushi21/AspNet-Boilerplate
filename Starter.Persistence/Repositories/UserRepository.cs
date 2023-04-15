using Starter.Application.Repositories;
using Starter.Domain.Entities;
using Starter.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Starter.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
  public UserRepository(DataContext context) : base(context)
  {
  }

  public bool IsEmailAlreadyExist(string email)
  {
    return Context.Users.Any(x => x.Email == email);
  }

  public User GetByEmail(string email)
  {
    return Context.Users.FirstOrDefault(x => x.Email == email);
  }
}