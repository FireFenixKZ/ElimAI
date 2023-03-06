using Catalog.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.GetCategoryListQuery
{
    public class GetCategoryListQuery : IRequest<Result<List<CategoryDTO>>>
    {
    }
}
