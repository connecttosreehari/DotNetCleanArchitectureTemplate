using MediatR;

namespace Application.UseCases.Users.Commands.CreateUserCommand;

public class CreateUserCommand : IRequest<bool>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
