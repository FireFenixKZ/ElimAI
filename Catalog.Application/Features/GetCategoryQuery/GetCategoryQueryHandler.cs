using AutoMapper;
using Catalog.Application.Contracts;
using Catalog.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.GetCategoryQuery
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Result>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public GetCategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return Result.Success(_mapper.Map<CategoryDTO>(await _categoryService.GetCategoryById(request.CategoryId)));
        }
    }
}
