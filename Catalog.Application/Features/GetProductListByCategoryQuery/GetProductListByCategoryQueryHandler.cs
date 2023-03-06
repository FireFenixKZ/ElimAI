using AutoMapper;
using Catalog.Application.Contracts;
using Catalog.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.GetProductListByCategoryQuery
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return Result.Success(
                _mapper.Map<List<ProductDTO>>(await _productService.GetProductsByCategory(request.CategoryId)));
        }
    }
}
