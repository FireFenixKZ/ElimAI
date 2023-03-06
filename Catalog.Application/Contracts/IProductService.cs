using Catalog.Domain.Entity;

namespace Catalog.Application.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetProductListAsync();
        Task<Product?> GetProductAsync(int productId);
        Task<List<Product>> GetProductsByCategory(int categoryUrl);
        Task<List<Product>> FindProductsBySearchText(string searchText);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
        Task<List<Product>> GetFeaturedProducts();
        Task<List<Product>> GetAdminProducts();
        Task AddProduct(Product product);
        Task ChangeCategory(int productId, int categoryId);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);

    }
}
