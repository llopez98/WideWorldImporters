using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WideWorldImporters.AuthSvr.Token
{
    public interface ITokenService
    {
        SigningCredentials GetSigningCredentials();
        Task<List<Claim>> GetClaims(IdentityUser user);
        JwtSecurityToken GenerateTokenOption(SigningCredentials signingCredentials, List<Claim> claims);
    }
}
