using Snackis.Domain.Entities;

namespace Snackis.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task AddAsync(Comment comment);
        Task DeleteAsync(int id);
        Task<List<Comment>> GetCommentsByPostAsync(int postId);
    }
}