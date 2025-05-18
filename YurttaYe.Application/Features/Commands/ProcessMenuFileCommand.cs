// src/YurttaYe.Application/Features/Commands/ProcessMenuFileCommand.cs
using MediatR;
using System.IO;
using YurttaYe.Application.Common;

namespace YurttaYe.Application.Features.Commands
{
    public class ProcessMenuFileCommand : IRequest<Result>
    {
        public Stream FileStream { get; set; }
        public string FileExtension { get; set; }
    }
}