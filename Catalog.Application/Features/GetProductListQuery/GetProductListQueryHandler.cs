using AutoMapper;
using Catalog.Application.Contracts;
using Catalog.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.GetProductListQuery
{
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, Result>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public SearchProductQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            return Result.Success(
                _mapper.Map<List<ProductDTO>>(await _productService.GetProductListAsync()));
        }
    }
}
