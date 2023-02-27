using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var categories = await _categoryService.GetCategoryDtos();
            if (categories == null)
                return NotFound();

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDto>> Get(int? id)
        {
            var result = await _categoryService.GetById(id);
            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();

            await _categoryService.Create(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { Id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int? id, [FromBody] CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
                return BadRequest();
            if (categoryDto == null)
                return NotFound();

            await _categoryService.Update(categoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDto>> Delete(int? id)
        {
            var result = await _categoryService.GetById(id);
            if (result == null)
                return BadRequest();

            await _categoryService.Delete(id);
            return Ok(result);
        }
    }
}
