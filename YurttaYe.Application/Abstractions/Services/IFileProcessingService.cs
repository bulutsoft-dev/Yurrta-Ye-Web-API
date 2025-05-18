using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using YurttaYe.Domain.Entities;

namespace YurttaYe.Application.Abstractions.Services
{
    public interface IFileProcessingService
    {
        Task<List<Menu>> ProcessFileAsync(Stream fileStream, string fileExtension);
    }
}