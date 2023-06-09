﻿using Starter.Domain.Common;

namespace Starter.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
  void Create(T entity);
  void Update(T entity);
  void Delete(T entity);
  T Get(Guid id);
  List<T> GetAll();
}