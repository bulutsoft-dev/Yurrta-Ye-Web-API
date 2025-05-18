// src/YurttaYe.WebApi/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YurttaYe.Application.Abstractions.Services;

namespace YurttaYe.WebApi.Controllers
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Username and password are required.");

            var isValid = await _authService.ValidateCredentialsAsync(request.Username, request.Password);
            if (!isValid)
                return Unauthorized("Invalid username or password.");

            var token = await _authService.GenerateJwtTokenAsync(request.Username, "Admin");
            return Ok(token);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}