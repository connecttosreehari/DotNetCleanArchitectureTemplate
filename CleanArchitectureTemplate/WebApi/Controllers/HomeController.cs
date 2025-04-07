using Application.UseCases.Products.Commands.CreateProduct;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class HomeController : BaseController
{
    [HttpPost]
    public async Task<bool> Create(CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }
}
