using DevTesteInovage.Application.Models;
using DevTesteInovage.Application.Services.Implementations;
using DevTesteInovage.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevTesteInovage.API.Controllers
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
        public async Task<IActionResult> Get()
        {
            var model = await _productService.GetProductsAsync();

            if (model == null)
                return NotFound("Products not found");

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _productService.GetProductDetailsByIdAsync(id);

            if (model == null)
                return NotFound("Products not found");
           
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProductInputModel model)
        {
            if (model == null)
                return BadRequest("Data Invalid");

            await _productService.AddProductAsync(model);

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductInputModel model)
        {
            await _productService.UpdateProductAsync(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, InactivedProductInputModel model)
        {
            await _productService.InactivedProductAsync(model);

            return NoContent();
        }
    }
}
