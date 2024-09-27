using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeriodicTaskManagementSystem.Business.DTOs.Users;
using PeriodicTaskManagementSystem.Business.Interfaces;
using PeriodicTaskManagementSystem.Business.Services;

namespace PeriodicTaskManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddUserDto user)
        {
            try
            {
                await _userService.AddAsync(user);
                return Ok($"User {user.FirstName} {user.LastName} was created successfuly");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserDto user)
        {
            try
            {
                var userinDb = await _userService.GetByIdAsync(user.Id);

                if (userinDb == null)
                {
                    return NotFound("User not found!");
                }
                await _userService.UpdateAsync(user);
                return Ok($"User {user.FirstName} {user.LastName} was updated successflly!");
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
                var userinDb = await _userService.GetByIdAsync(id);

                if (userinDb == null)
                {
                    return NotFound($"User with Id {id} was not found!");
                }

                await _userService.DeleteAsync(id);
                return Ok($"User {userinDb.FirstName} {userinDb.LastName} was deleted successfully!");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
