namespace Snackis.Presentation.Models
{
    public class PostApiModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public string UserName { get; set; }
        public string UserImage { get; set; }

        public List<CommentApiModel> Comments { get; set; } = new();
    }
    public class CommentApiModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string UserName { get; set; }
        public string UserImage { get; set; }
    }
}
