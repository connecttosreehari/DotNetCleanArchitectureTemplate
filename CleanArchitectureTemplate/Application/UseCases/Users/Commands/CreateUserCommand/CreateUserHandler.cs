using MediatR;

namespace Application.UseCases.Users.Commands.CreateUserCommand;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
{
    public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
