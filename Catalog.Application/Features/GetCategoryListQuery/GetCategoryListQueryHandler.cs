using Catalog.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.GetCategoryListQuery
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, Result<CategoryDTO>>
    {
        public async Task<Result<CategoryDTO>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return Result.Success(new CategoryDTO());
        }
    }
}
