using Arkitektur.Business.DTOs.RoleDtos;
using Arkitektur.Business.Services.RoleServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService roleService) : ControllerBase
    {
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto dto)
        {
            var response = await roleService.CreateRole(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ResultRoleDto>>> GetAll()
        {
            var response=await roleService.GetAllRolesAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
