using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Interfaces;

interface IApplicationDbContext
{
    DbSet<Product> Products { get; set; }
}
