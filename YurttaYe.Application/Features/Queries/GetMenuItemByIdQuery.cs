// src/YurttaYe.Application/Features/Queries/GetMenuItemByIdQuery.cs
using MediatR;
using YurttaYe.Application.DTOs;

namespace YurttaYe.Application.Features.Queries
{
    public class GetMenuItemByIdQuery : IRequest<MenuItemDto>
    {
        public int Id { get; set; }
    }
}