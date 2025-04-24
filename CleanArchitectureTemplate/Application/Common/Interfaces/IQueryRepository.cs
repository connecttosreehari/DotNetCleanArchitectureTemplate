namespace Application.Common.Interfaces;
public interface IQueryRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(string sql, object param = null);
    Task<T?> FindSingleAsync(string sql, object param = null);
}
