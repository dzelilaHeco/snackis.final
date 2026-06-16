using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snackis.Application.Interfaces;
using Snackis.Domain.Entities;
using Snackis.Domain.Interfaces;
using Snackis.Infrastructure.Repositories;

namespace Snackis.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;

        public CommentService(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            comment.CreatedAt = DateTime.UtcNow;

            await _commentRepo.AddAsync(comment);
        }

        public async Task<List<Comment>> GetCommentsAsync(int postId)
        {
            return await _commentRepo.GetCommentsByPostAsync(postId);
        }
        public async Task CreateAsync(Comment comment)
        {
            comment.CreatedAt = DateTime.UtcNow;
            await _commentRepo.AddAsync(comment);
        }
    }
}
