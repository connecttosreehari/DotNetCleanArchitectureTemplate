using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>, IDisposable where TEntity : EntityBase
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    private bool _isDisposed;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
        _isDisposed = false;
    }
    
    public async Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracked = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public void Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void Dispose()
    {
        if (_context != null)
            _context.Dispose();
        _isDisposed = true;
    }
}
