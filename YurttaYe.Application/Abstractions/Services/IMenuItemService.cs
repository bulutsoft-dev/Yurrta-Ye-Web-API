// src/YurttaYe.Application/Abstractions/Services/IMenuItemService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using YurttaYe.Application.DTOs;

namespace YurttaYe.Application.Abstractions.Services
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemDto>> GetAllAsync();
        Task<MenuItemDto> GetByIdAsync(int id);
        Task AddAsync(MenuItemCreateDto dto);
        Task UpdateAsync(int id, MenuItemCreateDto dto);
        Task DeleteAsync(int id);
    }
}