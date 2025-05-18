// src/YurttaYe.Application/Features/Commands/CreateMenuItemCommand.cs
using MediatR;
using YurttaYe.Application.Common;
using YurttaYe.Application.DTOs;

namespace YurttaYe.Application.Features.Commands
{
    public class CreateMenuItemCommand : IRequest<Result>
    {
        public MenuItemCreateDto MenuItem { get; set; }
    }
}