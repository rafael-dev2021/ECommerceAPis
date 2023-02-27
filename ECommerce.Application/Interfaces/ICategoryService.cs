using ECommerce.Application.DTOs;

namespace ECommerce.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoryDtos();
        Task<CategoryDto> GetById(int? id);

        Task Create(CategoryDto categoryDto);
        Task Update(CategoryDto categoryDto);
        Task Delete(int? id);
    }
}
