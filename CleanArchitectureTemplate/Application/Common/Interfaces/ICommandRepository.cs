namespace Application.Common.Interfaces;

public interface ICommandRepository<TEntity>
 where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity, CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
}