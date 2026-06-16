using Snackis.Domain.Entities;

namespace Snackis.Application.Interfaces
{
    public interface IPrivateMessageService
    {
        Task<List<PrivateMessage>> GetConversationAsync(string userId, string otherUserId);
        Task SendMessageAsync(PrivateMessage message);
        Task CreateAsync(PrivateMessage message);
        Task<List<PrivateMessage>> GetInboxAsync(string userId);
    }
}