using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Snackis.Infrastructure.Data;

namespace Snackis.API.Controllers
{
    [ApiController]
    [Route("api/Discussion")]
    public class DiscussionController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DiscussionController(MyDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("topic/{topicId}")]
        public async Task<IActionResult> GetByTopic(int topicId)
        {
            var posts = await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Topic)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .Where(p => p.TopicId == topicId)
                .OrderBy(p => p.CreatedAt)
                .ToListAsync();

            var result = posts.Select(p => new
            {
                p.Id,
                p.Text,
                p.UserId, 
                CreatedAt = p.CreatedAt,
                Author = p.User?.DisplayName ?? p.User?.UserName ?? "Okänd",
                AuthorImage = p.User?.Image,
                Topic = p.Topic?.Name,
                Comments = p.Comments
                     .OrderBy(c => c.CreatedAt)
                     .Select(c => new
                     {
                         c.Id,
                         c.Text,
                         c.UserId,
                         CreatedAt = c.CreatedAt,
                         Author = c.User?.DisplayName ?? c.User?.UserName ?? "Okänd",
                         AuthorImage = c.User?.Image
                     })
            });

            return Ok(result);
        }
    }
}