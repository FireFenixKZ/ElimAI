using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.GetCategoryQuery
{
    public class GetCategoryQuery : IRequest<Result>
    {
        public int CategoryId { get; set; }

        public GetCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
