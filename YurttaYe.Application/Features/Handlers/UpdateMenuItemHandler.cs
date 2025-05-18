// src/YurttaYe.Application/Features/Handlers/UpdateMenuItemHandler.cs
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Application.Common;
using YurttaYe.Application.Features.Commands;
using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Application.Features.Handlers
{
    public class UpdateMenuItemHandler : IRequestHandler<UpdateMenuItemCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMenuItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var menuItem = await _unitOfWork.MenuItems.GetByIdAsync(request.Id);
            if (menuItem == null)
                return Result.Failure("Menu item not found");

            var dto = request.MenuItem;
            menuItem.Update(
                name: dto.Name,
                category: dto.Category,
                gramaj: new Gramaj(dto.GramajValue, dto.GramajUnit),
                price: dto.PriceValue.HasValue ? new Price(dto.PriceValue.Value, dto.PriceCurrency) : null,
                calorie: dto.CalorieValue.HasValue ? new Calorie(dto.CalorieValue.Value) : null
            );

            await _unitOfWork.MenuItems.UpdateAsync(menuItem);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}