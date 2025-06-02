using Microsoft.EntityFrameworkCore;
using ProductDemo.Domain.Interfaces;
using ProductDemo.Domain.Models;

namespace ProductDemo.Domain.Repository
{
    public class ProductsRepository : IProductRepository
    {
        private readonly ProductsDbContext _productsDbContext;

        public ProductsRepository(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productsDbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productsDbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productsDbContext.Products.AddAsync(product);
            await _productsDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _productsDbContext.Products.FindAsync(id);
            if (existingProduct == null) return false;

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Category = product.Category;
            existingProduct.UnitPrice = product.UnitPrice;
            existingProduct.Discontinued = product.Discontinued;
            existingProduct.ProductionData = product.ProductionData;

            await _productsDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productsDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return false;

            _productsDbContext.Products.Remove(product);
            await _productsDbContext.SaveChangesAsync();
            return true;
        }
    }
}
