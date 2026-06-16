using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Snackis.Application.Interfaces;
using Snackis.Domain.Entities;
using Snackis.Domain.Interfaces;
using Snackis.Infrastructure.Data;

namespace Snackis.Application.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<List<Topic>> GetAllAsync()
        {
            return await _topicRepository.GetAllAsync();
        }

        public async Task<List<Topic>> GetByCategoryIdAsync(int categoryId)
        {
            return await _topicRepository.GetByCategoryIdAsync(categoryId);
        }

        public async Task CreateAsync(string name, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            await _topicRepository.AddAsync(new Topic
            {
                Name = name,
                CategoryId = categoryId
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _topicRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Topic topic)
        {
            await _topicRepository.UpdateAsync(topic);
        }
        public async Task<Topic?> GetByIdAsync(int id)
        {
            return await _topicRepository.GetByIdAsync(id);
        }
        public async Task<List<Topic>> GetThreadsAsync()
        {
            return await _topicRepository.GetThreadsAsync();
        }
    }
}
