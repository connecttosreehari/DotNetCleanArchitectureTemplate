using MediatR;

namespace Application.UseCases.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<bool>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; } = default!;
}
