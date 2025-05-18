// src/YurttaYe.Application/Services/MenuItemService.cs
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using YurttaYe.Application.Abstractions.Services;
using YurttaYe.Application.DTOs;
using YurttaYe.Application.Features.Commands;
using YurttaYe.Application.Features.Queries;

namespace YurttaYe.Application.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMediator _mediator;

        public MenuItemService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<MenuItemDto>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllMenuItemsQuery());
        }

        public async Task<MenuItemDto> GetByIdAsync(int id)
        {
            return await _mediator.Send(new GetMenuItemByIdQuery { Id = id });
        }

        public async Task AddAsync(MenuItemCreateDto dto)
        {
            var result = await _mediator.Send(new CreateMenuItemCommand { MenuItem = dto });
            if (!result.IsSuccess)
                throw new System.Exception(result.ErrorMessage);
        }

        public async Task UpdateAsync(int id, MenuItemCreateDto dto)
        {
            var result = await _mediator.Send(new UpdateMenuItemCommand { Id = id, MenuItem = dto });
            if (!result.IsSuccess)
                throw new System.Exception(result.ErrorMessage);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                throw new System.Exception("Menu item not found");

            var result = await _mediator.Send(new UpdateMenuItemCommand { Id = id, MenuItem = null }); // Soft delete or implement DeleteCommand
            if (!result.IsSuccess)
                throw new System.Exception(result.ErrorMessage);
        }
    }
}