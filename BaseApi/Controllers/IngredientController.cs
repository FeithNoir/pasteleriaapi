using Microsoft.AspNetCore.Mvc;
using Pasteleria.Business.Interfaces.Services;
using Pasteleria.Shared.DTOs;
using Base.Shared.Extensions;

namespace Pasteleria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _ingredientService.GetAllIngredientsAsync();
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _ingredientService.GetIngredientByIdAsync(id);
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateIngredientDto ingredientDto)
        {
            var result = await _ingredientService.AddIngredientAsync(ingredientDto);
            return result.IsSuccessful ? CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] IngredientDto ingredientDto)
        {
            if (id != ingredientDto.Id)
            {
                return BadRequest("Ingredient ID in URL does not match Ingredient ID in body.");
            }
            var result = await _ingredientService.UpdateIngredientAsync(ingredientDto);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _ingredientService.DeleteIngredientAsync(id);
            return result.IsSuccessful ? NoContent() : BadRequest(result);
        }
    }
}
