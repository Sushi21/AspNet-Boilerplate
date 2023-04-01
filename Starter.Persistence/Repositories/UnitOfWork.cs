using Starter.Application.Repositories;
using Starter.Persistence.Context;

namespace Starter.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext context;

    public UnitOfWork(DataContext context)
    {
        this.context = context;
    }
    public Task Save(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}