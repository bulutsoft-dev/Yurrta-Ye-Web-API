// src/YurttaYe.Application/Features/Queries/GetAllMenuItemsQuery.cs
using System.Collections.Generic;
using MediatR;
using YurttaYe.Application.DTOs;

namespace YurttaYe.Application.Features.Queries
{
    public class GetAllMenuItemsQuery : IRequest<IEnumerable<MenuItemDto>>
    {
        public IEnumerable<MenuItemDto> Items { get; set; }
    }
}