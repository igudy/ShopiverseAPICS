// namespace is used for grouping
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CategoryAPI.Models;

namespace ProductAPI.Models
{
    public class ProductAPIModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }


        // It uses the Id property of the CategoryModel class as a foreign key to establish a 
        // relationship between the ProductModel and CategoryModel classes.
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public CategoryModel? Category { get; set; } //Navigating Property
    }
}