using Microsoft.AspNetCore.Mvc;
using Pasteleria.Business.Interfaces.Services;
using Pasteleria.Shared.DTOs;

namespace Pasteleria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _recipeService.GetAllRecipesAsync();
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _recipeService.GetRecipeByIdAsync(id);
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateRecipeDto recipeDto)
        {
            var result = await _recipeService.AddRecipeAsync(recipeDto);
            return result.IsSuccessful ? CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RecipeDto recipeDto)
        {
            if (id != recipeDto.Id)
            {
                return BadRequest("Recipe ID in URL does not match Recipe ID in body.");
            }
            var result = await _recipeService.UpdateRecipeAsync(recipeDto);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _recipeService.DeleteRecipeAsync(id);
            return result.IsSuccessful ? NoContent() : BadRequest(result);
        }
    }
}
