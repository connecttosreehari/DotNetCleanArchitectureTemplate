using Domain.Entities;

namespace Domain.Common.Interfaces;

public interface IGenericRepository<TEntity>
 where TEntity : EntityBase
{
    Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(bool tracked = true, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity, CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
}