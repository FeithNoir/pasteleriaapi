using Microsoft.AspNetCore.Mvc;
using Pasteleria.Business.Interfaces.Services;
using Pasteleria.Shared.DTOs;
<<<<<<< HEAD
using Base.Shared.Extensions;

namespace Pasteleria.Api.Controllers
=======

namespace BaseApi.Controllers
>>>>>>> a35fed2aeafc6041218fa22d78ef697c789d5bd7
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
<<<<<<< HEAD
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
            return result.IsSuccessful ? CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result) : BadRequest(result);
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
=======
        private readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListIngredientDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDto>> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateIngredientDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateIngredientDto dto)
        {
            try
            {
                await _service.UpdateAsync(dto);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
>>>>>>> a35fed2aeafc6041218fa22d78ef697c789d5bd7
        }
    }
}
