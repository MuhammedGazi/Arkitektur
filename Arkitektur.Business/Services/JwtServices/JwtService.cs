using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TokenDtos;
using Arkitektur.Business.Options;
using Arkitektur.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Arkitektur.Business.Services.JwtServices
{
    public class JwtService(IOptions<JwtTokenOptions> tokenOptions,
                            UserManager<AppUser> userManager) : IJwtService
    {
        private readonly JwtTokenOptions _tokenOptions = tokenOptions.Value;
        public async Task<TokenResponseDto> GenerateTokenAsync(AppUser user)
        {
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_tokenOptions.Key));

            var userRoles = await userManager.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                new Claim("fullName",string.Join(" ",user.FirstName,user.LastName)),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audince,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_tokenOptions.ExpireInMinutes),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

            var responseDto = new TokenResponseDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                ExpireTime = DateTime.UtcNow.AddMinutes(_tokenOptions.ExpireInMinutes)
            };

            return  responseDto;
        }
    }
}
