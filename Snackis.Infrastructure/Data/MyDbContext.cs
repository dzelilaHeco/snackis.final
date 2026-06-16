using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Snackis.Domain.Entities;

namespace Snackis.Infrastructure.Data
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : IdentityDbContext<MyUser>(options)
    {

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
