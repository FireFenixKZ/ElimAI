using Catalog.Application.DTO;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.EditCategoryCommand
{
    public class EditCategoryCommand : IRequest<Result>
    {
        public CategoryDTO Category { get; set; }

        public EditCategoryCommand(CategoryDTO category)
        {
            Category = category;
        }
    }
}
