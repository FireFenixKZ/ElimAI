using Catalog.Application.Contracts;
using Catalog.Domain.Entity;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repository.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        #region Seller & Admin
        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var dbProduct = await _context.Products.FindAsync(productId);
            if (dbProduct == null)
            {
                return;
            }

            dbProduct.Deleted = true;
            await _context.SaveChangesAsync();
        }
        public async Task ChangeCategory(int productId, int categoryId)
        {
            var dbProduct = await _context.Products.FindAsync(productId);
            if (dbProduct == null)
            {
                return;
            }

            dbProduct.CategoryId = categoryId;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAdminProducts()
        {
            return await _context.Products
                .Where(p => !p.Deleted)
                .Include(p => p.Variants.Where(v => !v.Deleted))
                .ThenInclude(v => v.ProductType)
                .Include(p => p.Images)
                .ToListAsync();
        }
        #endregion

        public async Task<List<Product>> GetFeaturedProducts()
        {
            return await _context.Products
                .Where(p => p.Featured && p.Visible && !p.Deleted)
                .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                .Include(p => p.Images)
                .ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int productId)
        {
            return await _context.Products
                .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                .ThenInclude(v => v.ProductType)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted && p.Visible);
        }

        public async Task<List<Product>> GetProductListAsync()
        {
            return await _context.Products
                     .Where(p => p.Visible && !p.Deleted)
                     .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                     .Include(p => p.Images)
                     .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await _context.Products
                    .Where(p => p.CategoryId == categoryId &&
                        p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                    .Include(p => p.Images)
                    .ToListAsync();
        }

        #region SearchProduct
        //public async Task<ProductSearchResult> SearchProducts(string searchText, int page)
        //{
        //    var pageResults = 2f;
        //    var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResults);
        //    var products = await _context.Products
        //                        .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
        //                            p.Description != null && p.Description.ToLower().Contains(searchText.ToLower()) &&
        //                            p.Visible && !p.Deleted)
        //                        .Include(p => p.Variants)
        //                        .Include(p => p.Images)
        //                        .Skip((page - 1) * (int)pageResults)
        //                        .Take((int)pageResults)
        //                        .ToListAsync();

        //    var response = new ServiceResponse<ProductSearchResult>
        //    {
        //        Data = new ProductSearchResult
        //        {
        //            Products = products,
        //            CurrentPage = page,
        //            Pages = (int)pageCount
        //        }
        //    };

        //    return response;
        //}
        #endregion

        public async Task UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (dbProduct == null)
            {
                return;
            }

            dbProduct.Title = product.Title;
            dbProduct.Description = product.Description;
            dbProduct.ImageUrl = product.ImageUrl;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Visible = product.Visible;
            dbProduct.Featured = product.Featured;

            var productImages = dbProduct.Images;
            _context.Images.RemoveRange(productImages);

            dbProduct.Images = product.Images;
            #region temp

            //foreach (var variant in product.Variants)
            //{
            //    var dbVariant = await _context.ProductVariants
            //        .SingleOrDefaultAsync(v => v.ProductId == variant.ProductId &&
            //            v.ProductTypeId == variant.ProductTypeId);
            //    if (dbVariant == null)
            //    {
            //        variant.ProductType = null;
            //        _context.ProductVariants.Add(variant);
            //    }
            //    else
            //    {
            //        dbVariant.ProductTypeId = variant.ProductTypeId;
            //        dbVariant.Price = variant.Price;
            //        dbVariant.OriginalPrice = variant.OriginalPrice;
            //        dbVariant.Visible = variant.Visible;
            //        dbVariant.Deleted = variant.Deleted;
            //    }
            //}

            #endregion
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products
                                .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                                            p.Description != null && p.Description.ToLower().Contains(searchText.ToLower()) &&
                                    p.Visible && !p.Deleted)
                                .Include(p => p.Variants)
                                .ToListAsync();
        }
    }
}
