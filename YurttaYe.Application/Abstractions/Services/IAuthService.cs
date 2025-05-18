using System.Threading.Tasks;

namespace YurttaYe.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<bool> ValidateCredentialsAsync(string username, string password);
        Task<string> GenerateJwtTokenAsync(string username, string role);
    }
}