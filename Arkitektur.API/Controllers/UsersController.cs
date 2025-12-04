using Arkitektur.Business.DTOs.UserDtos;
using Arkitektur.Business.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            var response=await userService.CreateUserAsync(userDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
