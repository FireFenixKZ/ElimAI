using AutoMapper;
using Catalog.Application.Contracts;
using Catalog.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.GetCategoryListQuery
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, Result<List<CategoryDTO>>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public GetCategoryListQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<Result<List<CategoryDTO>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            return Result.Success(_mapper.Map<List<CategoryDTO>>(await _categoryService.GetCategories()));
        }
    }
}
