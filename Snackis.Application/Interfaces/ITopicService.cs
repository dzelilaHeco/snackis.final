using Snackis.Domain.Entities;

namespace Snackis.Application.Interfaces
{
    public interface ITopicService
    {
        Task CreateAsync(string name, int categoryId);
        Task DeleteAsync(int id);
        Task<List<Topic>> GetAllAsync();
        Task<List<Topic>> GetByCategoryIdAsync(int categoryId);
        Task UpdateAsync(Topic topic);
        Task<Topic?> GetByIdAsync(int id);
        Task<List<Topic>> GetThreadsAsync();
    }
}