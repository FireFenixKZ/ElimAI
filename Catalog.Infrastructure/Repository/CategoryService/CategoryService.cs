using Catalog.Application.Contracts;
using Catalog.Domain.Entity;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repository.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);

            if (category is null) return;

            category.Deleted = true;
            await _context.SaveChangesAsync();

        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetAdminCategories()
        {
            return await _context.Categories
                 .Where(c => !c.Deleted)
                 .ToListAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories
                .Where(c => !c.Deleted && c.Visible)
                .ToListAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
