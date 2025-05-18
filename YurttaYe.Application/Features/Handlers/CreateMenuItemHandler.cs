// src/YurttaYe.Application/Features/Handlers/CreateMenuItemHandler.cs
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Application.Common;
using YurttaYe.Application.Features.Commands;
using YurttaYe.Domain.Entities;
using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Application.Features.Handlers
{
    public class CreateMenuItemHandler : IRequestHandler<CreateMenuItemCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMenuItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var dto = request.MenuItem;
            var menuItem = new MenuItem(
                name: dto.Name,
                category: dto.Category,
                gramaj: new Gramaj(dto.GramajValue, dto.GramajUnit),
                price: dto.PriceValue.HasValue ? new Price(dto.PriceValue.Value, dto.PriceCurrency) : null,
                calorie: dto.CalorieValue.HasValue ? new Calorie(dto.CalorieValue.Value) : null
            );

            await _unitOfWork.MenuItems.AddAsync(menuItem);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}