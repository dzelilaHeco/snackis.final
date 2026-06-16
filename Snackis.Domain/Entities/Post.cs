using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snackis.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }

        public MyUser User { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
