using DevTesteInovage.Application.Models;
using DevTesteInovage.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevTesteInovage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _purchaseService.GetPurchasesAsync();

            if (model == null)
                return NotFound("Purchases not found");

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _purchaseService.GetPurchaseDetailsByIdAsync(id);

            if (model == null)
                return NotFound("Purchases not found");

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddPurchaseInputModel model)
        {
            if (model == null)
                return BadRequest("Data Invalid");

            await _purchaseService.AddPurchaseAsync(model);

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpPut("{id}/delivered")]
        public async Task<IActionResult> Delivered(int id, UpdatePurchaseInputModel model)
        {
            bool statusUpdated =  await _purchaseService.DeliveredPurchaseAsync(model);

            if(statusUpdated)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Only a purchase with a status onTheWay could have a Delivered status.");
            }

            
        }

        [HttpPut("{id}/ontheway")]
        public async Task<IActionResult> OnTheWay(int id, UpdatePurchaseInputModel model)
        {
            bool statusUpdated =  await _purchaseService.OnTheWayPurchaseAsync(model);

            if (statusUpdated)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Only a purchase with a status created could have a onTheWay status.");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id, UpdatePurchaseInputModel model)
        {
            bool statusUpdated =  await _purchaseService.CancelledPurchaseAsync(model);

            if (statusUpdated)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("You can't cancel a purchase it has been already delivered.");
            }

        }
    }
}
