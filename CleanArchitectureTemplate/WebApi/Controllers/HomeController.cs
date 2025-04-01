using Application.UseCases.Users.Commands.CreateUserCommand;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class HomeController : BaseController
{
    [HttpPost]
    public async Task<bool> Create(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }
}
