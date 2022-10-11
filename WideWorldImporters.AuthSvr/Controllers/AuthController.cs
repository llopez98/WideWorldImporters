using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WideWorldImporters.AuthSvr.Application.Dto;

namespace WideWorldImporters.AuthSvr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister userDto) {
            if(userDto == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new IdentityUser
            {
                UserName = userDto.Email,
                Email = userDto.Email
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded) {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(errors);
            }

            await _userManager.AddToRoleAsync(user, "common");

            return StatusCode(201);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserAuthentication userDto) {
            var user = await _userManager.FindByNameAsync(userDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userDto.Password)) {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
