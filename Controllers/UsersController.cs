using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using FilmRental.Models.DTOs;
using FilmRental.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmRental.Controllers
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

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var usersList = await _userService.GetAllUsersAsync();
            return Ok(usersList);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var theUser = await _userService.GetUserByIdAsync(id);
            return Ok(theUser);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<int>> CreateUser([FromBody]UserDTO userDTO)
        {
            var j = await _userService.AddUserAsync(userDTO);
            return Ok(j);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDto)
        {
            if(id != userDto.UserId)
            {
                return BadRequest();
            }
            await _userService.UpdateUserAsync(userDto);
            return Ok();
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeletedUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
