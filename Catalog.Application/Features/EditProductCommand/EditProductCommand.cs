using Catalog.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.EditProductCommand
{
    public class EditProductCommand : IRequest<Result>
    {
        public ProductDTO ProductDto { get; set; }

        public EditProductCommand(ProductDTO productDto)
        {
            ProductDto = productDto;
        }
    }
}
