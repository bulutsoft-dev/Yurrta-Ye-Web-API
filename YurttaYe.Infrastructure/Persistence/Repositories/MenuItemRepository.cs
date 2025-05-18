// src/YurttaYe.Infrastructure/Persistence/Repositories/MenuItemRepository.cs
using Microsoft.EntityFrameworkCore;
using YurttaYe.Application.Abstractions;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Domain.Entities;

namespace YurttaYe.Infrastructure.Persistence.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly AppDbContext _context;

        public MenuItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem> GetByIdAsync(int id)
        {
            return await _context.MenuItems.FindAsync(id) ?? throw new Exception("Menu item not found");
        }

        public async Task AddAsync(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var menuItem = await GetByIdAsync(id);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }
    }
}