using System.Net.NetworkInformation;
using Snackis.Domain.Entities;


namespace Snackis.Application.Interfaces
{
    public interface IPostService
    {
        Task CreatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<List<Post>> GetByTopicAsync(int topicId);
        Task<Post?> GetThreadAsync(int postId);
        //save

    }
}