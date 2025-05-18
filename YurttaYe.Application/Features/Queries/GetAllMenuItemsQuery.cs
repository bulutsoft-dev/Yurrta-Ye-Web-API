// src/YurttaYe.Application/Features/Queries/GetAllMenuItemsQuery.cs
using MediatR;
using System.Collections.Generic;
using YurttaYe.Application.DTOs;

namespace YurttaYe.Application.Features.Queries
{
    public class GetAllMenuItemsQuery : IRequest<IEnumerable<MenuItemDto>>
    {
    }
}