﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WideWorldImporters.AuthSvr.Application.Dto;
using WideWorldImporters.AuthSvr.Models;
using WideWorldImporters.AuthSvr.Token;

namespace WideWorldImporters.AuthSvr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister userDto)
        {
            if (userDto == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User { UserName = userDto.Email, Email = userDto.Email };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(errors);
            }

            await _userManager.AddToRoleAsync(user, "warehouse");

            return StatusCode(201);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserAuthentication userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userDto.Password))
            {
                return Unauthorized(new AuthResponseDto { IsAuthSuccessful = false ,ErrorMessage = "Invalid Authentication" });
            }

            var signingCredentials = _tokenService.GetSigningCredentials();
            var claims = await _tokenService.GetClaims(user);
            var tokenOptions = _tokenService.GenerateTokenOption(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpriryTime = DateTime.Now.AddHours(1);

            await _userManager.UpdateAsync(user);

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token, RefreshToken = user.RefreshToken, ExpTime = user.RefreshTokenExpriryTime, Id = user.Id, Roles = roles });
        }
    }
}
