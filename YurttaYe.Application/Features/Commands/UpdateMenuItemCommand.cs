// src/YurttaYe.Application/Features/Commands/UpdateMenuItemCommand.cs
using MediatR;
using YurttaYe.Application.Common;
using YurttaYe.Application.DTOs;

namespace YurttaYe.Application.Features.Commands
{
    public class UpdateMenuItemCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public MenuItemCreateDto MenuItem { get; set; }
    }
}