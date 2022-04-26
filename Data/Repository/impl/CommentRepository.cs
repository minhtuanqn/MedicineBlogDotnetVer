
using Data.Database;
using Data.Entity;
using Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.impl
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly AppDbContext dbContext;

        public CommentRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Comment>> GetAllByPostIdAsync(Guid id)
        {
            try
            {
                IQueryable<Comment> query = dbContext.comments.Where(c => c.postId == id && c.status == true).AsNoTracking();
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }

        public async Task<List<Comment>> GetAllCmtByRootIdAsync(Guid id)
        {
            try
            {
                IQueryable<Comment> query = dbContext.comments.Where(c => c.parentId == id && c.status == true).AsNoTracking();
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }

        public async Task<List<Comment>> GetAllRootCmtByPostIdAsync(Guid id)
        {
            try
            {
                IQueryable<Comment> query = dbContext.comments.Where(c => c.postId == id && c.status == true && c.parentId == c.id).AsNoTracking();
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }
    }
}
