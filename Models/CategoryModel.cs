using System.ComponentModel.DataAnnotations;
using ProductAPI.Models;

namespace CategoryAPI.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<ProductAPIModel>? Products { get; set; }  // One to many relationship
    }
}