using Arkitektur.Business.DTOs.TokenDtos;
using Arkitektur.Business.DTOs.UserDtos;
using Arkitektur.Business.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            var response=await userService.CreateUserAsync(userDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(LoginDto loginDto)
        {
            var  response=await userService.LoginAsync(loginDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
