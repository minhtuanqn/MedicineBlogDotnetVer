
using Data.Database;
using Data.Entity;

namespace Data.Repository.impl
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly AppDbContext dbContext;

        public CommentRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
