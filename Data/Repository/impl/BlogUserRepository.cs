using Data.Database;
using Data.Entity;

namespace Data.Repository.impl
{
    public class BlogUserRepository : GenericRepository<BlogUser>, IBlogUserRepository
    {
        private readonly AppDbContext dbContext;

        public BlogUserRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
