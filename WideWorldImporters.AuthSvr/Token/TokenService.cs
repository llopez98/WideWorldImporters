﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WideWorldImporters.AuthSvr.Models;

namespace WideWorldImporters.AuthSvr.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        private readonly UserManager<User> _userManager;

        public TokenService(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
            _userManager = userManager;
        }

        public string GenerateRefreshToken()
        {
            var randomNum = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNum);
                return Convert.ToBase64String(randomNum);
            }
        }

        public JwtSecurityToken GenerateTokenOption(
            SigningCredentials signingCredentials,
            List<Claim> claims
        )
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings["validIssuer"],
                audience: _jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }

        public async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            return claims;
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings["securityKey"])
                ),
                ValidateLifetime = false,
                ValidIssuer = _jwtSettings["validIssuer"],
                ValidAudience = _jwtSettings["validAudience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(
                token,
                tokenValidationParameters,
                out securityToken
            );

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (
                jwtSecurityToken == null
                || !jwtSecurityToken.Header.Alg.Equals(
                    SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase
                )
            )
            {
                throw new SecurityTokenException("Invalid Token");
            }

            return principal;
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings["securityKey"]);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
