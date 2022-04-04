using Data.Entity;
using System;

namespace Data.Repository
{
    public interface IPostRepository : IGenericRepository<Post> 
    {
        public Post FindPostByTitle(string title);

        public Post FindPostByTitleAndNotId(Guid id, string title);
    }
}
