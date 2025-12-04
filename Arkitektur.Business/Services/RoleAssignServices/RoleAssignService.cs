using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleAssignDtos;
using Arkitektur.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.RoleAssignService
{
    public class RoleAssignService(UserManager<AppUser> _userManager,
                                    RoleManager<AppRole> _roleManager) : IRoleAssignService
    {
        public async Task<BaseResult<object>> AssignRoleAsync(List<AssingRoleDto> assingRoleDtos)
        {
            var userId = assingRoleDtos.Select(x => x.UserId).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                return BaseResult<object>.Fail("User Not Found");
            }
            foreach (var assignRole in assingRoleDtos)
            {
                if (assignRole.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, assignRole.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, assignRole.RoleName);
                }
            }

            return BaseResult<object>.Success(new { Message = "Role Assign Successful" });
        }

        public async Task<BaseResult<List<AssingRoleDto>>> GetUserForRoleAssignAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                return BaseResult<List<AssingRoleDto>>.Fail("User Not Found");
            }
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            var roleAssignments = new List<AssingRoleDto>();
            foreach (var role in roles)
            {
                var assignRole = new AssingRoleDto
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                    RoleName = role.Name,
                    RoleExist = userRoles.Contains(role.Name)
                };
                roleAssignments.Add(assignRole);
            }

            return BaseResult<List<AssingRoleDto>>.Success(roleAssignments);
        }
    }
}
