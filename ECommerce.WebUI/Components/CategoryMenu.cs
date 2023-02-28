using ECommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryMenu(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetCategoryDtos();
            categories.OrderBy(x => x.CategoryName);
            return View(categories);
        }
    }
}
