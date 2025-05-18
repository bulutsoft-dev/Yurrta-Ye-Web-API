// src/YurttaYe.Application/Features/Handlers/ProcessMenuFileHandler.cs
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Application.Abstractions.Services;
using YurttaYe.Application.Common;
using YurttaYe.Application.Features.Commands;

namespace YurttaYe.Application.Features.Handlers
{
    public class ProcessMenuFileHandler : IRequestHandler<ProcessMenuFileCommand, Result>
    {
        private readonly IFileProcessingService _fileProcessingService;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessMenuFileHandler(IFileProcessingService fileProcessingService, IUnitOfWork unitOfWork)
        {
            _fileProcessingService = fileProcessingService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ProcessMenuFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var menus = await _fileProcessingService.ProcessFileAsync(request.FileStream, request.FileExtension);
                foreach (var menu in menus)
                {
                    foreach (var item in menu.Items)
                    {
                        await _unitOfWork.MenuItems.AddAsync(item);
                    }
                }
                await _unitOfWork.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error processing file: {ex.Message}");
            }
        }
    }
}