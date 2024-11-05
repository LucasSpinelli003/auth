using Microsoft.AspNetCore.Mvc;
using AuthApi.Models;
using AuthApi.Services;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Auth auth)
        {
            var newAuth = await _authService.CreateAuthAsync(auth);
            return Ok(newAuth);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Auth auth)
        {
            var token = await _authService.GenerateTokenAsync(auth.Login, auth.Password);

            if (token == null)
            {
                return Unauthorized("Login ou senha inválidos.");
            }

            return Ok(new { Token = token });
        }
    }
}
