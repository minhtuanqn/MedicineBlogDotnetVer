using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Topic> departments { get; set; }
    }
}
