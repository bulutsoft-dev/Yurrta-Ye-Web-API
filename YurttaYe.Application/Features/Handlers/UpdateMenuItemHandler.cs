// src/YurttaYe.Application/Features/Handlers/UpdateMenuItemHandler.cs
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Application.Common;
using YurttaYe.Application.Features.Commands;
using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Application.Features.Handlers
{
    public class UpdateMenuItemHandler : IRequestHandler<UpdateMenuItemCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMenuItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var menuItem = await _unitOfWork.MenuItems.GetByIdAsync(request.Id);
            if (menuItem == null)
                return Result.Failure("Menu item not found");

            var dto = request.MenuItem;
            menuItem.Update(
                dto.Name,
                dto.Category,
                new Gramaj(dto.GramajValue, dto.GramajUnit),
                dto.PriceValue.HasValue ? new Price(dto.PriceValue.Value, dto.PriceCurrency) : null,
                dto.CalorieValue.HasValue ? new Calorie(dto.CalorieValue.Value) : null);

            await _unitOfWork.MenuItems.UpdateAsync(menuItem);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}