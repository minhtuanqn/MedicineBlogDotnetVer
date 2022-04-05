using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Topic> topics { get; set; }

        public DbSet<Post> posts { get; set; }

        public DbSet<Tag> tags { get; set; }

        public DbSet<Comment> comments { get; set; }

        public DbSet<BlogUser> users { get; set; }
    }
}
