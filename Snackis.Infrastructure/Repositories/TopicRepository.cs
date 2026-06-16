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
    public class TopicRepository : ITopicRepository
    {
        private readonly MyDbContext _context;
        public TopicRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Topic>> GetAllAsync()
        {
            return await _context.Topics
                .Include(t => t.Category)
                .ToListAsync();
        }

        public async Task<List<Topic>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Topics
                .Where(t => t.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task AddAsync(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic != null)
            {
                _context.Topics.Remove(topic);

                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Topic topic)
        {
            _context.Topics.Update(topic);
            await _context.SaveChangesAsync();
        }
        public async Task<Topic?> GetByIdAsync(int id)
        {
            return await _context.Topics
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Topic>> GetThreadsAsync()
        {
            return await _context.Topics
                .Include(t => t.Category)
                .Include(t => t.Posts)
                    .ThenInclude(p => p.User)
                .ToListAsync();
        }
    }
}
