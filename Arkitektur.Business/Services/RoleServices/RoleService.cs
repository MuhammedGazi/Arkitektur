using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleDtos;
using Arkitektur.Entity.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.RoleServices
{
    public class RoleService(RoleManager<AppRole> roleManager) : IRoleService
    {
        public async Task<BaseResult<object>> CreateRole(CreateRoleDto dto)
        {
            var role = dto.Adapt<AppRole>();
            var result=await roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Errors);
            }

            return BaseResult<object>.Success(new { Message = "Role Created" });
        }

        public async Task<BaseResult<List<ResultRoleDto>>> GetAllRolesAsync()
        {
            var roles = await roleManager.Roles.ToListAsync();
            var result = roles.Adapt<List<ResultRoleDto>>();
            return BaseResult<List<ResultRoleDto>>.Success(result);
        }
    }
}
