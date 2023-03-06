using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.GetProductListByCategoryQuery
{
    public class GetProductByIdQuery : IRequest<Result>
    {
        public int CategoryId { get; set; }

        public GetProductByIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
