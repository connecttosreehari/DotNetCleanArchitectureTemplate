using Domain.Entities;

namespace Application.UseCases.Products.Commands.CreateProduct;

public record CreateProductResponse
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; set; } = default!;
    public decimal ProductPrice { get; set; } = default!;
}


public static class CreateProductResponseMapper
{
    public static CreateProductResponse Map(Product source)
    {
        return new CreateProductResponse
        {
            ProductId = source.Id,
            ProductName = source.Name,
            ProductDescription = source.Description,
            ProductPrice = source.Price,
        };
    }
}