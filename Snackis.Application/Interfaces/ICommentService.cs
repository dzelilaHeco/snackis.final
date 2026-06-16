using Snackis.Domain.Entities;

namespace Snackis.Application.Interfaces
{
    public interface ICommentService
    {
        Task AddCommentAsync(Comment comment);
        Task<List<Comment>> GetCommentsAsync(int postId);
        Task CreateAsync(Comment comment);
    }
}