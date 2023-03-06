using AutoMapper;
using Catalog.Application.Contracts;
using Catalog.Domain.Entity;
using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryService.AddCategory(_mapper.Map<Category>(request));
            return Result.Success();
        }
    }
}
