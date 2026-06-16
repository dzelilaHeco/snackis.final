using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Snackis.Domain.Entities;
using Snackis.Domain.Interfaces;
using Snackis.Infrastructure.Data;

namespace Snackis.Infrastructure.Repositories
{
    public class PrivateMessageRepository : IPrivateMessageRepository
    {
        private readonly MyDbContext _context;
        public PrivateMessageRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task SendAsync(PrivateMessage message)
        {
            message.SentAt = DateTime.UtcNow;

            await _context.PrivateMessages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PrivateMessage>> GetConversationAsync(string userId, string otherUserId)
        {
            return await _context.PrivateMessages
                .Where(m =>
                    (m.SenderId == userId && m.ReceiverId == otherUserId) ||
                    (m.SenderId == otherUserId && m.ReceiverId == userId))
                .Include(m => m.Sender)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }
        public async Task AddAsync(PrivateMessage message)
        {
            await _context.PrivateMessages.AddAsync(message);

            await _context.SaveChangesAsync();
        }
        public async Task<List<PrivateMessage>> GetInboxAsync(string userId)
        {
            return await _context.PrivateMessages
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();
        }
    }
}
