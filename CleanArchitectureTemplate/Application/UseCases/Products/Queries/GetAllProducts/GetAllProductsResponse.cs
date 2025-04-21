namespace Application.UseCases.Products.Queries.GetAllProducts;
public record GetAllProductsResponse
{
    public List<Product> Products { get; set; } = new();
}

public record Product
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; } = default!;
}