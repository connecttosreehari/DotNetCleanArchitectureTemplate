using Domain.Entities;

namespace Application.Common.Interfaces;
public interface IQueryUnitOfWork
{
    IQueryRepository<Product> Products { get; }
}
