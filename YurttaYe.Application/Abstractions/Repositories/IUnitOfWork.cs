// src/YurttaYe.Application/Abstractions/Repositories/IUnitOfWork.cs
using System;
using System.Threading.Tasks;

namespace YurttaYe.Application.Abstractions.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMenuItemRepository MenuItems { get; }
        Task<int> SaveChangesAsync();
    }
}