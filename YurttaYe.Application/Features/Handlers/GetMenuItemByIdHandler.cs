// src/YurttaYe.Application/Features/Handlers/GetMenuItemByIdHandler.cs
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Application.DTOs;
using YurttaYe.Application.Features.Queries;

namespace YurttaYe.Application.Features.Handlers
{
    public class GetMenuItemByIdHandler : IRequestHandler<GetMenuItemByIdQuery, MenuItemDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMenuItemByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MenuItemDto> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.MenuItems.GetByIdAsync(request.Id);
            return _mapper.Map<MenuItemDto>(item);
        }
    }
}