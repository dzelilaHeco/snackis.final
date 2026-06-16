using Snackis.Domain.Entities;

namespace Snackis.Domain.Interfaces
{
    public interface IPrivateMessageRepository
    {
        Task<List<PrivateMessage>> GetConversationAsync(string userId, string otherUserId);
        Task SendAsync(PrivateMessage message);
        Task AddAsync(PrivateMessage message);
        Task<List<PrivateMessage>> GetInboxAsync(string userId);
    }
}