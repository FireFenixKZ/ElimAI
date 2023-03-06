using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.SearchProductQuery
{
    public class SearchProductQuery : IRequest<Result>
    {
        public string SearchText { get; set; }

        public SearchProductQuery(string searchText)
        {
            SearchText = searchText;
        }
    }
}
