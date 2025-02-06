using Microsoft.EntityFrameworkCore;
using CategoryAPI.Models;
using ProductAPI.Services;
using shopiversecs.Data;

namespace CategoryAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CategoryModel> CreateCategoryAsync(CategoryModel category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryModel category)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null) return false;

            existingCategory.Name = category.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
