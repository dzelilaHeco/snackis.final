using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Snackis.Domain.Entities
{
    public class MyUser : IdentityUser
    {
        public string? Image { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAdmin { get; set; }
        public string? DisplayName { get; set; }

        public List<Post> Posts { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();

        public List<PrivateMessage> SentMessages { get; set; } = new();
        public List<PrivateMessage> ReceivedMessages { get; set; } = new();
    }
}
