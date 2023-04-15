using Starter.Application.Repositories;
using Starter.Domain.Common;
using Starter.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Starter.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
  protected readonly DataContext Context;

  public BaseRepository(DataContext context)
  {
    Context = context;
  }

  public void Create(T entity)
  {
    Context.Add(entity);
  }

  public void Update(T entity)
  {
    Context.Update(entity);
  }

  public void Delete(T entity)
  {
    entity.DateCreated = DateTimeOffset.UtcNow;
    Context.Update(entity);
  }

  public T Get(Guid id)
  {
    return Context.Set<T>().FirstOrDefault(x => x.Id == id);
  }

  public List<T> GetAll()
  {
    return Context.Set<T>().ToList();
  }
}