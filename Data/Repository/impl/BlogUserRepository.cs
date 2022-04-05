using Data.Database;
using Data.Entity;
using Data.Exceptions;
using System;
using System.Linq;

namespace Data.Repository.impl
{
    public class BlogUserRepository : GenericRepository<BlogUser>, IBlogUserRepository
    {
        private readonly AppDbContext dbContext;

        public BlogUserRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public BlogUser FindUserByEmail(string email)
        {
            try
            {
                BlogUser blogUser = dbContext.users.Where(user => user.email == email).FirstOrDefault();
                return blogUser;
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }
    }
}
