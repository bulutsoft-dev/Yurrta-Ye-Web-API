// src/YurttaYe.Application/Abstractions/Repositories/IMenuItemRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using YurttaYe.Domain.Entities;

namespace YurttaYe.Application.Abstractions.Repositories
{
    public interface IMenuItemRepository
    {
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<MenuItem> GetByIdAsync(int id);
        Task AddAsync(MenuItem menuItem);
        Task UpdateAsync(MenuItem menuItem);
        Task DeleteAsync(int id);
    }
}