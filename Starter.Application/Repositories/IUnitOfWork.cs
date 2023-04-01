﻿namespace Starter.Application.Repositories;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}