using Snackis.Domain.Entities;

namespace Snackis.Domain.Interfaces
{
    public interface ITopicRepository
    {
        Task AddAsync(Topic topic);
        Task DeleteAsync(int id);
        Task<List<Topic>> GetAllAsync();
        Task<List<Topic>> GetByCategoryIdAsync(int categoryId);
        Task UpdateAsync(Topic topic);
        Task<Topic?> GetByIdAsync(int id);
        Task<List<Topic>> GetThreadsAsync();
    }
}