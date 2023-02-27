using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Minimum {2} and maximum {1} characters")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
