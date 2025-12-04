using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.Services.RoleServices
{
    public interface IRoleService
    {
        Task<BaseResult<object>> CreateRole(CreateRoleDto dto);
        Task<BaseResult<List<ResultRoleDto>>> GetAllRolesAsync();
    }
}
