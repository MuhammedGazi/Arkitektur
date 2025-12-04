using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.UserDtos;

namespace Arkitektur.Business.Services.UserServices
{
    public interface IUserService
    {
        Task<BaseResult<object>> CreateUserAsync(CreateUserDto dto);
    }
}
