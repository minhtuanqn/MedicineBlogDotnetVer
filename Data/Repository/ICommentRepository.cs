using Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        public Task<List<Comment>> GetAllByPostIdAsync(Guid id);

        public Task<List<Comment>> GetAllRootCmtByPostIdAsync(Guid id);

        public Task<List<Comment>> GetAllCmtByRootIdAsync(Guid id);
    }
}
