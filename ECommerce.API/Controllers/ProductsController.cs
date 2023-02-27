using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await _productService.GetProductDtos();
            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDto>> Get(int? id)
        {
            var result = await _productService.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            await _productService.Add(productDto);

            return new CreatedAtRouteResult("GetProduct", new { Id = productDto.Id }, productDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int? id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
                return BadRequest();
            if (productDto == null)
                return NotFound();

            await _productService.Update(productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDto>> Delete(int? id)
        {
            var result = await _productService.GetById(id);
            if (result == null)
                return BadRequest();

            await _productService.Delete(id);
            return Ok(result);
        }
    }
}

