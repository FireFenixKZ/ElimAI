using AutoMapper;
using Catalog.Application.Contracts;
using Catalog.Domain.Entity;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.EditProductCommand
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Result>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public EditProductCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.AddProduct(_mapper.Map<Product>(request.ProductDto));
            return Result.Success();
        }
    }
}
