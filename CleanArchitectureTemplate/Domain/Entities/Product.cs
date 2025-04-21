namespace Domain.Entities;

public class Product : EntityBase
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; } = default!;
}
