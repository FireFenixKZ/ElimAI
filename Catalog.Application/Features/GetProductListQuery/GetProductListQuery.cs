using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.GetProductListQuery
{
    public class SearchProductQuery : IRequest<Result>
    {
    }
}
