// src/YurttaYe.Application/Features/Commands/ProcessMenuFileCommand.cs
using System.Collections.Generic;
using System.IO;
using MediatR;
using YurttaYe.Application.Common;
using YurttaYe.Domain.Entities;

namespace YurttaYe.Application.Features.Commands
{
    public class ProcessMenuFileCommand : IRequest<Result>
    {
        public Stream FileStream { get; set; }
        public string FileExtension { get; set; }
    }
}