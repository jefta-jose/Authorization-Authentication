using api.DTOs;
using api.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController (IUser userService) : ControllerBase
    {
        private readonly IUser _userService = userService;

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto newUser)
        {
            if(newUser == null)
            {
                return BadRequest("Empty Data");
            }

            var result = await _userService.CreateNewUser(newUser);

            return Ok(result);
        }
    }
}
