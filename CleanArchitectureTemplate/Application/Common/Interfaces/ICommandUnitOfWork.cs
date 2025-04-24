using Application.Common.Interfaces;

namespace Application.Common.Interfaces;

public interface ICommandUnitOfWork 
{
    ICommandRepository<T> GetRepository<T>()
        where T : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
}
