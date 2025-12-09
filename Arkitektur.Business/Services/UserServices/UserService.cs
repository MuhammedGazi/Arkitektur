using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TokenDtos;
using Arkitektur.Business.DTOs.UserDtos;
using Arkitektur.Business.Services.JwtServices;
using Arkitektur.Entity.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Arkitektur.Business.Services.UserServices
{
    public class UserService(UserManager<AppUser> userManager,IJwtService jwtService) : IUserService
    {
        public async Task<BaseResult<object>> CreateUserAsync(CreateUserDto dto)
        {
            var user = dto.Adapt<AppUser>();
            var result = await userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Errors);
            }

            return BaseResult<object>.Success(new { Message = "User Created" });
        }

        public async Task<BaseResult<TokenResponseDto>> LoginAsync(LoginDto loginDto)
        {
            var user=await userManager.FindByEmailAsync(loginDto.Email);
            if (user is null)
            {
                return BaseResult<TokenResponseDto>.Fail("User Not Found");
            }

            var result=await userManager.CheckPasswordAsync(user,loginDto.Password);
            if (!result)
            {
                return BaseResult<TokenResponseDto>.Fail("Email or Password  is incorrect ");
            }
            var tokenResponse=await  jwtService.GenerateTokenAsync(user);
            return BaseResult<TokenResponseDto>.Success(tokenResponse);
        }
    }
}
