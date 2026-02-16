using Microsoft.AspNetCore.Mvc;
using Pasteleria.Business.Interfaces.Services;
using Pasteleria.Shared.DTOs;

namespace Pasteleria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly IInventoryItemService _inventoryItemService;

        public InventoryItemController(IInventoryItemService inventoryItemService)
        {
            _inventoryItemService = inventoryItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _inventoryItemService.GetAllInventoryItemsAsync();
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _inventoryItemService.GetInventoryItemByIdAsync(id);
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateInventoryItemDto inventoryItemDto)
        {
            var result = await _inventoryItemService.AddInventoryItemAsync(inventoryItemDto);
            return result.IsSuccessful ? CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] InventoryItemDto inventoryItemDto)
        {
            if (id != inventoryItemDto.Id)
            {
                return BadRequest("InventoryItem ID in URL does not match InventoryItem ID in body.");
            }
            var result = await _inventoryItemService.UpdateInventoryItemAsync(inventoryItemDto);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _inventoryItemService.DeleteInventoryItemAsync(id);
            return result.IsSuccessful ? NoContent() : BadRequest(result);
        }
    }
}
