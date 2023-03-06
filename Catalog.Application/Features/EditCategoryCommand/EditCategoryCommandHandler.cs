using AutoMapper;
using Catalog.Application.Contracts;
using Catalog.Domain.Entity;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.EditCategoryCommand
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Result>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public EditCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryService.UpdateCategory(_mapper.Map<Category>(request));
            return Result.Success();
        }
    }
}
