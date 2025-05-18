// src/YurttaYe.Infrastructure/Persistence/Repositories/UnitOfWork.cs

using YurttaYe.Application.Abstractions;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Infrastructure.Persistence;

namespace YurttaYe.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IMenuItemRepository MenuItems { get; }

        public UnitOfWork(AppDbContext context, IMenuItemRepository menuItemRepository)
        {
            _context = context;
            MenuItems = menuItemRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}