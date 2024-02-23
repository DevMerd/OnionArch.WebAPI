using MediatR;
using OnionArch.Application.Features.Products.Rules;
using OnionArch.Application.Interfaces.UnitOfWorks;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRules _productRules;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules)
        {
            _unitOfWork = unitOfWork;
            _productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

            //if (products.Any(p => p.Title == request.Title))
            //    throw new Exception("Aynı başlıkta ürün olamaz.");

            await _productRules.ProductTitleMustNotBeSame(products, request.Title);

            Product product = new Product(request.Title, request.Description, request.BrandId, request.Price, request.Discount);
            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if (await _unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId,
                    });
                }
                await _unitOfWork.SaveAsync();
                //Double save cause first db operation is for product. I cant use productCategory until product has been created.
                //So first save for product and second save for pC.
            }
            return Unit.Value;
        }
    }
}
