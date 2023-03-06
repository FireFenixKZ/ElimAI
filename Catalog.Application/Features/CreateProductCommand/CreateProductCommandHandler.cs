using AutoMapper;
using Catalog.Application.Contracts;
using Catalog.Domain.Entity;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.CreateProductCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.AddProduct(_mapper.Map<Product>(request.ProductDto));
            return Result.Success();
        }
    }
}
