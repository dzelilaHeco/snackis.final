using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snackis.Application.Interfaces;
using Snackis.Domain.Entities;
using Snackis.Domain.Interfaces;

namespace Snackis.Application.Services
{
    public class PrivateMessageService : IPrivateMessageService
    {
        private readonly IPrivateMessageRepository _privateMessageRepo;

        public PrivateMessageService(IPrivateMessageRepository privateMessageRepo)
        {
            _privateMessageRepo = privateMessageRepo;
        }

        public async Task SendMessageAsync(PrivateMessage message)
        {
            message.SentAt = DateTime.UtcNow;

            await _privateMessageRepo.SendAsync(message);
        }

        public async Task<List<PrivateMessage>> GetConversationAsync(string userId, string otherUserId)
        {
            return await _privateMessageRepo.GetConversationAsync(userId, otherUserId);
        }
        public async Task CreateAsync(PrivateMessage message)
        {
            message.SentAt = DateTime.UtcNow;

            await _privateMessageRepo.AddAsync(message);
        }
        public async Task<List<PrivateMessage>> GetInboxAsync(string userId)
        {
            return await _privateMessageRepo.GetInboxAsync(userId);
        }
    }
}
