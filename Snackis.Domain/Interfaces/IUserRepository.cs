using Snackis.Domain.Entities;

namespace Snackis.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(MyUser user);
        Task DeleteAsync(int id);
        Task<List<MyUser>> GetAllAsync();
        Task<MyUser?> GetByEmailAsync(string email);
        Task<MyUser?> GetByIdAsync(string id);
        Task UpdateAsync(MyUser user);
    }
}