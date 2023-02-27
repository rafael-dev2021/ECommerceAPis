using ECommerce.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECommerce.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Minimum {2} and maximum {1} characters")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "Description is required")]
        [StringLength(5000, MinimumLength = 15, ErrorMessage = "Minimum {2} and maximum {1} characters")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [StringLength(600, ErrorMessage = "Maximum {1} characters")]
        [DisplayName("Image")]
        public string Image { get; set; }


        [Required(ErrorMessage = "Stock is required")]
        [Range(1, 99999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DisplayName("Favorite")]
        public bool Favorite { get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
    }
}
