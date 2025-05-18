using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Domain.Entities;
using YurttaYe.Infrastructure.Persistence;

namespace YurttaYe.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}