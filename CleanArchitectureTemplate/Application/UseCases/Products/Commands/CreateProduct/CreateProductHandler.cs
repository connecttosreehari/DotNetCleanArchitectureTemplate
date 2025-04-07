using MediatR;

namespace Application.UseCases.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
{
    public Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
