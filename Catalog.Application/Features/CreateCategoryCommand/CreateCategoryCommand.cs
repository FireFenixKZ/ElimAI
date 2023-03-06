using Catalog.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<Result>
    {
        public CategoryDTO Category { get; set; }

        public CreateCategoryCommand(CategoryDTO category)
        {
            Category = category;
        }
    }
}
