using Snackis.Domain.Entities;

namespace Snackis.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task UpdateAsync(Post post);
        Task AddAsync(Post post);
        Task DeleteAsync(int id);
        Task<List<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(int id);
        Task<List<Post>> GetByTopicAsync(int topicId);
        Task<List<Post>> GetLatestPostsAsync(int count);
    }
}