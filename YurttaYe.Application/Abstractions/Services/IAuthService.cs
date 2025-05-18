// src/YurttaYe.Application/Abstractions/Services/IAuthService.cs
namespace YurttaYe.Application.Abstractions.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username, string role);
        bool ValidateCredentials(string username, string password);
    }
}