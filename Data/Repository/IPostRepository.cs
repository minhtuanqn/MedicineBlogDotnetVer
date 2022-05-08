using Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IPostRepository : IGenericRepository<Post> 
    {
        public Post FindPostByTitle(string title);

        public Post FindPostByTitleAndNotId(Guid id, string title);

        public Task<List<Post>> FindPostByTopicNameAsync(string id);
    }
}
