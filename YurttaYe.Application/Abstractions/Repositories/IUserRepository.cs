using System.Threading.Tasks;
using YurttaYe.Domain.Entities;

namespace YurttaYe.Application.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
    }
}