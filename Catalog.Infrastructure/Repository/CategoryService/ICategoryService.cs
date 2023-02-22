using Catalog.Domain.Entity;

namespace Catalog.Infrastructure.Repository.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<List<Category>> GetAdminCategories();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
