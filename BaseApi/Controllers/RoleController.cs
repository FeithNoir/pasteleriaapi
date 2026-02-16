using Base.Shared.Auth.Auxiliar;
using Base.Shared.Auth.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Base.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if(roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var role = new IdentityRole()
            {
                Name = dto.Name,
            };
            var isCreated = await _roleManager.CreateAsync(role);
            if (isCreated.Succeeded)
            {
                return Ok(new AuthResult()
                {
                    Message = "Registro creado con exito",
                    Result = true,
                });
            }
            else
            {
                var errors = isCreated.Errors.Select(e => e.Description).ToList();
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = errors
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(string id, [FromBody] RoleDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existingRole = await _roleManager.FindByIdAsync(id);
            if (existingRole == null) return NotFound();

            existingRole.Name = updateDto.Name;
            var result = await _roleManager.UpdateAsync(existingRole);
            if (result.Succeeded)
            {
                return Ok(new AuthResult()
                {
                    Message = "Registro editado con exito",
                    Result = true,
                });
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = errors
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok(new AuthResult()
                {
                    Message = "Registro eliminado con exito",
                    Result = true,
                });
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = errors
                });
            }
        }
    }
}