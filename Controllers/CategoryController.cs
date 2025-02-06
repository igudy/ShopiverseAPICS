using Microsoft.AspNetCore.Mvc;
using CategoryAPI.Models;
using CategoryAPI.Services;

namespace CategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Categories controller inherits from ControllerBase(Concept of Inheritance)
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Get all categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        // Get category by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        // Create a new category
        [HttpPost]
        public async Task<IActionResult> PostCategory(CategoryModel category)
        {
            var createdCategory = await _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.Id }, createdCategory);
        }

        // Update a category
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryModel category)
        {
            var success = await _categoryService.UpdateCategoryAsync(id, category);
            if (!success) return NotFound();
            return NoContent();
        }

        // Delete a category
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var success = await _categoryService.DeleteCategoryAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}