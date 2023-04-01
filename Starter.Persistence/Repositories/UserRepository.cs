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

  public Task<bool> IsEmailAlreadyExist(string email, CancellationToken cancellationToken)
  {
    return Context.Users.AnyAsync(x => x.Email == email, cancellationToken);
  }

  public Task<User> GetByEmail(string email, CancellationToken cancellationToken)
  {
    return Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
  }
}