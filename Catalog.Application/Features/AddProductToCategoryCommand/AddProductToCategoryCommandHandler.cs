using Catalog.Application.Contracts;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.AddProductToCategoryCommand
{
    public class AddProductToCategoryCommandHandler : IRequestHandler<AddProductToCategoryCommand, Result>
    {
        private readonly IProductService _productService;
        public AddProductToCategoryCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Result> Handle(AddProductToCategoryCommand request, CancellationToken cancellationToken)
        {
            await _productService.ChangeCategory(request.ProductId, request.CategoryId);
            return Result.Success();
        }
    }
}
