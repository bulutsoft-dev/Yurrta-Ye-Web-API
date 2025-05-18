// src/YurttaYe.Application/Features/Handlers/GetAllMenuItemsHandler.cs
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Application.DTOs;
using YurttaYe.Application.Features.Queries;

namespace YurttaYe.Application.Features.Handlers
{
    public class GetAllMenuItemsHandler : IRequestHandler<GetAllMenuItemsQuery, IEnumerable<MenuItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllMenuItemsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuItemDto>> Handle(GetAllMenuItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.MenuItems.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuItemDto>>(items);
        }
    }
}