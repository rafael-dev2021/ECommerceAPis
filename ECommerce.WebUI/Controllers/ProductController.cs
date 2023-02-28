using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string categoryId)
        {
            IEnumerable<ProductDto> productDtos;
            string currentCategory = string.Empty;
            var getList = await _productService.GetProductDtos();

            if (string.IsNullOrEmpty(categoryId))
            {
                productDtos = getList.OrderBy(x => x.Id);
                currentCategory = "All products";
            }
            else
            {
                productDtos = getList.Where(x => x.Category.CategoryName.Equals(categoryId)).OrderBy(x => x.ProductName);
                currentCategory = categoryId;
            }

            var productsVw = new ProductsViewModels()
            {
                ProductDtos = productDtos,
                CurrentCategory = currentCategory
            };
            return View(productsVw);
        }

        public async Task<IActionResult> Search(string searchStr)
        {
            IEnumerable<ProductDto> productDtos;
            string currentyCategory = string.Empty;
            var getList = await _productService.GetProductDtos();

            if (string.IsNullOrEmpty(searchStr))
            {
                productDtos = getList.OrderBy(x => x.ProductName);
                currentyCategory = "All Products";
            }
            else
            {
                productDtos = getList.Where(x => x.ProductName.ToLower().Contains(searchStr.ToLower()));
                if (productDtos.Any())
                    currentyCategory = "Products";
                else
                    currentyCategory = "Products not found";
            }
            return View("~/Views/Product/Index.cshtml", new ProductsViewModels()
            {
                ProductDtos = productDtos,
                CurrentCategory = currentyCategory
            });
        }
    }
}
