using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    private IQueryDispatcher _queryDispatcher;
    private ICommandDispatcher _commandDispatcher;

    protected IQueryDispatcher queryDispatcher => _queryDispatcher ??= HttpContext.RequestServices.GetRequiredService<IQueryDispatcher>();
    protected ICommandDispatcher commandDispatcher => _commandDispatcher ??= HttpContext.RequestServices.GetRequiredService<ICommandDispatcher>();
}
