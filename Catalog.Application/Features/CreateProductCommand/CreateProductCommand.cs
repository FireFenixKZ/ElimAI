using Catalog.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.CreateProductCommand
{
    public class CreateProductCommand : IRequest<Result>
    {
        public ProductDTO ProductDto { get; set; }

        public CreateProductCommand(ProductDTO productDto)
        {
            ProductDto = productDto;
        }
    }
}
