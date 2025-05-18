// src/YurttaYe.Infrastructure/Persistence/Repositories/MenuItemRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Domain.Entities;
using YurttaYe.Infrastructure.Persistence;

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
            return await _context.MenuItems.FindAsync(id);
        }

        public async Task AddAsync(MenuItem menuItem)
        {
            await _context.MenuItems.AddAsync(menuItem);
        }

        public async Task UpdateAsync(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var menuItem = await GetByIdAsync(id);
            if (menuItem != null)
                _context.MenuItems.Remove(menuItem);
        }
    }
}