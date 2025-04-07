using Application.UseCases.Products.Commands.CreateProduct;
using FluentValidation;

namespace Application.UseCases.Products.Commands.CreateUserCommand;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(x => x.Description).NotEmpty()
            .WithMessage("Description is required.");

        RuleFor(x => x.Price).NotEmpty()
            .WithMessage("Price is required");
    }
}
