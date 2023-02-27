using ECommerce.Application.DTOs;

namespace ECommerce.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductDtos();
        Task<IEnumerable<ProductDto>> GetFavoriteDtos();
        Task<ProductDto> GetById(int? id);
        Task Add(ProductDto productDto);
        Task Update(ProductDto productDto);
        Task Delete(int? id);
    }
}
