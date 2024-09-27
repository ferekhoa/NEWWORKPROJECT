using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeriodicTaskManagementSystem.Business.DTOs.Roles;
using PeriodicTaskManagementSystem.Business.Interfaces;
using PeriodicTaskManagementSystem.DataAccess.Entities;

namespace PeriodicTaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(RoleDto role)
        {
            try
            {
                await _roleService.AddAsync(role);
                return Ok($"Role {role.Name} was created successfuly");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(RoleDto role)
        {
            try
            {
                var roleinDb = await _roleService.GetByIdAsync(role.Id);

                if (roleinDb == null)
                {
                    return NotFound("Employee not found!");
                }
                await _roleService.UpdateAsync(role);
                return Ok($"Role {role.Name} was updated successflly!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var roleinDb = await _roleService.GetByIdAsync(id);

                if (roleinDb == null)
                {
                    return NotFound($"Role with Id {id} was not found!");
                }

                await _roleService.DeleteAsync(id);
                return Ok($"Role {roleinDb.Name} was deleted successfully!");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var role = await _roleService.GetByIdAsync(id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
