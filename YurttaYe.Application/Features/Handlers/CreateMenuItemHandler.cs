// src/YurttaYe.Application/Features/Handlers/CreateMenuItemHandler.cs
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
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
        private readonly IMapper _mapper;

        public CreateMenuItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var dto = request.MenuItem;
            var menuItem = new MenuItem(
                dto.Name,
                dto.Category,
                new Gramaj(dto.GramajValue, dto.GramajUnit),
                dto.PriceValue.HasValue ? new Price(dto.PriceValue.Value, dto.PriceCurrency) : null,
                dto.CalorieValue.HasValue ? new Calorie(dto.CalorieValue.Value) : null,
                dto.Date);

            await _unitOfWork.MenuItems.AddAsync(menuItem);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}