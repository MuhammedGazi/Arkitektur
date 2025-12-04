using Arkitektur.Business.DTOs.RoleAssignDtos;
using Arkitektur.Business.Services.RoleAssignService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Build.Logging;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignsController(IRoleAssignService _roleAssignService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<AssingRoleDto>>> GetUserForRoleAssign(int id)
        {
            var response=await _roleAssignService.GetUserForRoleAssignAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssingRoleDto> assingRoleDtos)
        {
            var response=await _roleAssignService.AssignRoleAsync(assingRoleDtos);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
