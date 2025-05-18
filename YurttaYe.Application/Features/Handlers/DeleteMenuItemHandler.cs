using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Application.Common;
using YurttaYe.Application.Features.Commands;

namespace YurttaYe.Application.Features.Handlers
{
    public class DeleteMenuItemHandler : IRequestHandler<DeleteMenuItemCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMenuItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
        {
            var menuItem = await _unitOfWork.MenuItems.GetByIdAsync(request.Id);
            if (menuItem == null)
                return Result.Failure("Menu item not found");

            await _unitOfWork.MenuItems.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}