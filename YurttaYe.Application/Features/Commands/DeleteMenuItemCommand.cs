using MediatR;
using YurttaYe.Application.Common;

namespace YurttaYe.Application.Features.Commands
{
    public class DeleteMenuItemCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}