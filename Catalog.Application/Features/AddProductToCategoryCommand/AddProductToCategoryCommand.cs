using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.AddProductToCategoryCommand
{
    public class AddProductToCategoryCommand : IRequest<Result>
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public AddProductToCategoryCommand(int categoryId, int productId)
        {
            CategoryId = categoryId;
            ProductId = productId;
        }
    }
}
