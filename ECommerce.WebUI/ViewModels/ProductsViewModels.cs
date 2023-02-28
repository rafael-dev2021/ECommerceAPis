using ECommerce.Application.DTOs;

namespace ECommerce.WebUI.ViewModels
{
    public class ProductsViewModels
    {
        public IEnumerable<ProductDto> ProductDtos { get; set; }
        public string CurrentCategory { get; set; }
    }
}
