// src/YurttaYe.Infrastructure/Services/AuthService.cs
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YurttaYe.Application.Abstractions.Services;
using YurttaYe.Infrastructure.Persistence;

namespace YurttaYe.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;

        public AuthService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);
            return user != null;
        }

        public async Task<string> GenerateJwtTokenAsync(string username, string role)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user == null)
                throw new Exception("User not found");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}