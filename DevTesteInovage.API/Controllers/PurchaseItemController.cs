using DevTesteInovage.Application.Models;
using DevTesteInovage.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevTesteInovage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseItemController : ControllerBase
    {
        private readonly IPurchaseItemService _purchaseItemService;

        public PurchaseItemController(IPurchaseItemService purchaseItemService)
        {
            _purchaseItemService = purchaseItemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _purchaseItemService.GetPurchaseItensByIdAsync(id);

            if (model == null)
                return NotFound("Products not found");
            //se não achar, retornar NotFound()

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int productId,int purchaseId, AddPurchaseItemInputModel model)
        {
            if (model == null)
                return BadRequest("Data Invalid");

            await _purchaseItemService.AddPurchaseItemAsync(productId,purchaseId,model);

            return CreatedAtAction(nameof(GetById),
                new { id = model.Id, productId = productId, purchaseId = purchaseId }, model);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,UpdatePurchaseItemInputModel model)
        {
            await _purchaseItemService.UpdatePurchaseItemAsync(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _purchaseItemService.GetPurchaseItensByIdAsync(id);

            if (model == null)
                return NotFound("PurchaseItem not found");

            await _purchaseItemService.DeletePurchaseItemAsync(id);

            return NoContent();
        }
    }
}
