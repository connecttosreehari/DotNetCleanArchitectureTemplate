using Application.Common.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace Infrastructure.Repositories;

public class QueryRepository<T> : IQueryRepository<T> where T : class
{
    private readonly string _connectionString;

    public QueryRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    public async Task<T?> GetByIdAsync(int id)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<T>($"SELECT * FROM [{typeof(T).Name}] WHERE Id = @Id", new { Id = id });
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<T>($"SELECT * FROM [{typeof(T).Name}]");
    }

    public async Task<IEnumerable<T>> FindAsync(string sql, object param = null)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<T>(sql, param);
    }

    public async Task<T?> FindSingleAsync(string sql, object param = null)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(sql, param);
    }
}
