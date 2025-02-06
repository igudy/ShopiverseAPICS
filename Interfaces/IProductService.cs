using ProductAPI.Models;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductAPIModel>> GetProductsAsync();
        Task<ProductAPIModel?> GetProductByIdAsync(int id);
        Task<ProductAPIModel> CreateProductAsync(ProductAPIModel product);
        Task<bool> UpdateProductAsync(int id, ProductAPIModel product);
        Task<bool> DeleteProductAsync(int id);
    }
}
