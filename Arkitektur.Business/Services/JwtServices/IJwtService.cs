using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TokenDtos;
using Arkitektur.Entity.Entities;

namespace Arkitektur.Business.Services.JwtServices
{
    public interface IJwtService
    {
        Task<TokenResponseDto> GenerateTokenAsync(AppUser user);
    }
}
