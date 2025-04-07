using Domain.Entities;
using Domain.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Storage;
using Infrastructure.Common.Interfaces;

namespace Infrastructure.Common.Data;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed = false;
    private readonly IServiceProvider _serviceProvider;
    private readonly IApplicationDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();
    private IDbContextTransaction _transaction;

    public UnitOfWork(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _context = _serviceProvider.GetService<IApplicationDbContext>()!;
    }

    public IGenericRepository<T> GetRepository<T>()
        where T : EntityBase
    {
        if (_repositories.ContainsKey(typeof(T)))
        {
            return (IGenericRepository<T>)_repositories[typeof(T)];
        }

        var repository = _serviceProvider.GetService<IGenericRepository<T>>()
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
            await _transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await _transaction.RollbackAsync(cancellationToken);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
