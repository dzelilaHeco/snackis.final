using System.Text.Json;
using Snackis.Application.Interfaces;
using Snackis.Domain.Entities;
using Snackis.Domain.Interfaces;

namespace Snackis.Application.Services
{
    public class PostServiceApi : IPostService
    {
        private readonly IPostRepository _postRepo;
        private readonly HttpClient _client;

        public PostServiceApi(IPostRepository postRepo, IHttpClientFactory httpClient)
        {
            _postRepo = postRepo;
            _client = httpClient.CreateClient("PostClient");
        }

        public async Task<List<Post>> GetByTopicAsync(int topicId)
        {
            var response = await _client.GetAsync($"api/Discussion/topic/{topicId}");
            if (!response.IsSuccessStatusCode)
                return new List<Post>();

            var json = await response.Content.ReadAsStringAsync();
            var dtos = JsonSerializer.Deserialize<List<PostApiDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Omvandla DTO till Post
            var result = dtos?.Select(d => new Post
            {
                Id = d.Id,
                Text = d.Text,
                UserId = d.UserId,
                CreatedAt = d.CreatedAt,
                User = new MyUser { UserName = d.Author, Image = d.AuthorImage },
                Comments = d.Comments.Select(c => new Comment
                {
                    Id = c.Id,
                    Text = c.Text,
                    CreatedAt = c.CreatedAt,
                    User = new MyUser { UserName = c.Author, Image = c.AuthorImage }
                }).ToList()
            }).ToList();

            return result ?? new List<Post>();
        }

        public async Task CreatePostAsync(Post post)
        {
            await _postRepo.AddAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepo.DeleteAsync(id);
        }
        public async Task<Post?> GetThreadAsync(int postId)
        {
            return await _postRepo.GetByIdAsync(postId);
        }
        //----
        public class PostApiDto
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public string? UserId { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Author { get; set; }
            public string? AuthorImage { get; set; }
            public string? Topic { get; set; }
            public List<CommentApiDto> Comments { get; set; } = new();
        }

        public class CommentApiDto
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Author { get; set; }
            public string? AuthorImage { get; set; }
        }
    }
}