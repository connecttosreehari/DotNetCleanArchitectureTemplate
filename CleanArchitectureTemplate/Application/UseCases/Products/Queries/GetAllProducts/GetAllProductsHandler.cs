using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.Queries.GetAllProducts;

public class GetAllProductsHandler : IQueryHandler<GetAllProductsQuery, GetAllProductsResponse>
{
    public Task<GetAllProductsResponse> Handle(GetAllProductsQuery query, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}
