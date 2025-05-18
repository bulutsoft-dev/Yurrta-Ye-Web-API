// src/YurttaYe.Infrastructure/Persistence/Repositories/UnitOfWork.cs
using System.Threading.Tasks;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Infrastructure.Persistence;

namespace YurttaYe.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _menuItemRepository = new MenuItemRepository(context);
            _userRepository = new UserRepository(context);
        }

        public IMenuItemRepository MenuItems => _menuItemRepository;
        public IUserRepository Users => _userRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}