using Application.Common.Helper;
using Application.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using System.Runtime.InteropServices;

namespace Application.UseCases.Products.Commands.CreateProduct;

public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    private IUnitOfWork _unitOfWork;
    private IValidator<CreateProductCommand> _validator;

    public CreateProductHandler(IUnitOfWork unitOfWork,IValidator<CreateProductCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        _validator.Validate(request);

        var productRepo = _unitOfWork.GetRepository<Product>();
        var productDetails = Mapper<CreateProductCommand, Product>.Map(request);
        var product = await productRepo.AddAsync(productDetails, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return CreateProductResponseMapper.Map(product);
    }
}
