using Catalog.Domain.Entity;

namespace Catalog.Application.Contracts
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
        Task<Category?> GetCategoryById(int id);
        Task<List<Category>> GetAdminCategories();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
