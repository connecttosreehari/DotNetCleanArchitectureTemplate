using Application.UseCases.Products.Commands.CreateProduct;
using Application.UseCases.Products.Queries.GetAllProducts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class HomeController : BaseController
{
    [HttpPost]
    public async Task<bool> Create(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        return await commandDispatcher.Dispatch<CreateProductCommand, bool>(command, cancellationToken);
    }

    [HttpGet]
    public async Task<GetAllProductsResponse> GetAllProducts(GetAllProductsQuery query, CancellationToken cancellationToken = default)
    {
        return await commandDispatcher.Dispatch<GetAllProductsQuery, GetAllProductsResponse>(query, cancellationToken);
    }
}
