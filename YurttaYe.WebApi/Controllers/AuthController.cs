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
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (_authService.ValidateCredentials(model.Username, model.Password))
            {
                var token = _authService.GenerateJwtToken(model.Username, "Admin");
                return Ok(new { Token = token });
            }
            return Unauthorized("Invalid credentials");
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}