using FluentValidation;

namespace Application.UseCases.Users.Commands.CreateUserCommand;

public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FullName).NotEmpty()
            .WithMessage("Full name is required.");

        RuleFor(x => x.Email).NotEmpty()
            .WithMessage("Email is required.");

        RuleFor(x => x.Password).NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8)
            .WithMessage("Minmum of eight characters required for password.");
    }
}
