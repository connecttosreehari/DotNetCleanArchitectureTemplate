using Application.Common.Interfaces;
using Infrastructure.Common.Data;
using Infrastructure.Persistence.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

public static class ServiceConfiguration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ICommandUnitOfWork, CommandUnitOfWork>();
        services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
        services.AddScoped<IQueryUnitOfWork, QueryUnitOfWork>(provider => new QueryUnitOfWork(connectionString));
        services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
    }
}

