namespace Application.Common.Interfaces;

public interface IGenericRepository<TEntity>
 where TEntity : class
{
    Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(bool tracked = true, CancellationToken cancellationToken = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity, CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
}