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
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepo;

        public PostService(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<List<Post>> GetByTopicAsync(int topicId)
        {
            return await _postRepo.GetByTopicAsync(topicId);
        }

        public async Task<Post?> GetThreadAsync(int postId)
        {
            return await _postRepo.GetByIdAsync(postId);
        }

        public async Task CreatePostAsync(Post post)
        {
            post.CreatedAt = DateTime.UtcNow;

            await _postRepo.AddAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepo.DeleteAsync(id);
        }
    }
}
