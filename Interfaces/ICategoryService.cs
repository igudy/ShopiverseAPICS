using CategoryAPI.Models;

namespace CategoryAPI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
        Task<CategoryModel?> GetCategoryByIdAsync(int id);
        Task<CategoryModel> CreateCategoryAsync(CategoryModel category);
        Task<bool> UpdateCategoryAsync(int id, CategoryModel category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
