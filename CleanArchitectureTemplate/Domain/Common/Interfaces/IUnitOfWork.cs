using Domain.Entities;

namespace Domain.Common.Interfaces;

public interface IUnitOfWork 
{
    IGenericRepository<T> GetRepository<T>()
        where T : EntityBase;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
}
