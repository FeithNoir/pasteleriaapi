using Microsoft.AspNetCore.Mvc;
using Pasteleria.Business.Interfaces.Services;
using Pasteleria.Shared.DTOs;

namespace Pasteleria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly IRecipeIngredientService _recipeIngredientService;

        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService)
        {
            _recipeIngredientService = recipeIngredientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _recipeIngredientService.GetAllRecipeIngredientsAsync();
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _recipeIngredientService.GetRecipeIngredientByIdAsync(id);
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateRecipeIngredientDto recipeIngredientDto)
        {
            var result = await _recipeIngredientService.AddRecipeIngredientAsync(recipeIngredientDto);
            return result.IsSuccessful ? CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RecipeIngredientDto recipeIngredientDto)
        {
            if (id != recipeIngredientDto.Id)
            {
                return BadRequest("RecipeIngredient ID in URL does not match RecipeIngredient ID in body.");
            }
            var result = await _recipeIngredientService.UpdateRecipeIngredientAsync(recipeIngredientDto);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _recipeIngredientService.DeleteRecipeIngredientAsync(id);
            return result.IsSuccessful ? NoContent() : BadRequest(result);
        }
    }
}
