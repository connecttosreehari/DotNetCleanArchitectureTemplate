using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Common.Data;

public class CommandUnitOfWork : ICommandUnitOfWork, IDisposable
{
    private bool _disposed;
    private readonly IServiceProvider _serviceProvider;
    private readonly IApplicationDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();
    private IDbContextTransaction? _transaction;

    public CommandUnitOfWork(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _context = _serviceProvider.GetService<IApplicationDbContext>()!;
    }

    public ICommandRepository<T> GetRepository<T>()
        where T : class
    {
        if (_repositories.ContainsKey(typeof(T)))
        {
            return (ICommandRepository<T>)_repositories[typeof(T)];
        }

        var repository = _serviceProvider.GetService<ICommandRepository<T>>()
            ?? throw new InvalidOperationException("Repository is not registered in DI container");

        _repositories.Add(typeof(T), repository);

        return repository;
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await SaveChangesAsync(cancellationToken);
            await _transaction!.CommitAsync(cancellationToken);
        }
        catch
        {
            await RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await _transaction!.RollbackAsync(cancellationToken);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}
