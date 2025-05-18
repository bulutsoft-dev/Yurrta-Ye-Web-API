// src/YurttaYe.Application/Services/MenuItemService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
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
                throw new Exception(result.ErrorMessage);
        }

        public async Task UpdateAsync(int id, MenuItemCreateDto dto)
        {
            var result = await _mediator.Send(new UpdateMenuItemCommand { Id = id, MenuItem = dto });
            if (!result.IsSuccess)
                throw new Exception(result.ErrorMessage);
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _mediator.Send(new DeleteMenuItemCommand { Id = id });
            if (!result.IsSuccess)
                throw new Exception(result.ErrorMessage);
        }
    }
}