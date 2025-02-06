using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;
using shopiversecs.Data;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductAPIModel>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductAPIModel?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ProductAPIModel> CreateProductAsync(ProductAPIModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(int id, ProductAPIModel product)
        {
            if (id != product.Id)
            {
                return false;
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return _context.Products.Any(e => e.Id == id);
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
