using System.Threading.Tasks;

namespace YurttaYe.Application.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        IMenuItemRepository MenuItems { get; }
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}