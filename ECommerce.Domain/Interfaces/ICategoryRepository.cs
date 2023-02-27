﻿using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetByIdAsync(int? id);
        Task<Category> CreateAsync(Category category);
        Task<Category> RemoveAsync(Category category);
        Task<Category> UpdateAsync(Category category);
    }
}
