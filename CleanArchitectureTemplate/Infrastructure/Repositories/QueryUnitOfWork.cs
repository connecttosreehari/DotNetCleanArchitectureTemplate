using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories;
public class QueryUnitOfWork : IQueryUnitOfWork
{
    private readonly string _connectionString;
    private IQueryRepository<Product> _products;

    public QueryUnitOfWork(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IQueryRepository<Product> Products => _products ??= new QueryRepository<Product>(_connectionString);
}
