using Catalog.Application.Contracts;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.SearchProductQuery
{
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, Result>
    {
        private readonly IProductService _productService;
        public SearchProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Result> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.FindProductsBySearchText(request.SearchText);

            var result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(request.SearchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(request.SearchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return Result.Success(result);
        }
    }
}
