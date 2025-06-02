using ProductDemo.Domain.Models;

namespace ProductDemo.Application.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Retrives all products from the database.
        /// </summary>
        /// <returns>List of product.</returns>
        Task<IEnumerable<Product>> GetAllProductsAsync();

        /// <summary>
        /// Retrives a single product by its ID.
        /// </summary>
        /// <param name="id">Id of the product.</param>
        /// <returns>A single product.</returns>
        Task<Product?> GetProductByIdAsync(int id);

        /// <summary>
        /// Inserts a new product to the database.
        /// </summary>
        /// <param name="product">A new product.</param>
        /// <returns>Task.</returns>
        Task CreateProductAsync(Product product);

        /// <summary>
        /// Updates an existing product by its ID.
        /// </summary>
        /// <param name="id">Id of the existing product.</param>
        /// <param name="product">Existing product.</param>
        /// <returns>Returns True if update is successfull, Otherwise False.</returns>
        Task<bool> UpdateProductAsync(int id, Product product);

        /// <summary>
        /// Deletes an existing product by its ID.
        /// </summary>
        /// <param name="id">Id of the existing product.</param>
        /// <returns>Returns True if deletion is successfull, Otherwise False.</returns>
        Task<bool> DeleteProductAsync(int id);
    }
}
