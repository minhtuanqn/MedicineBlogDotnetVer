﻿using Data.Database;
using Data.Entity;
using Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.impl
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly AppDbContext dbContext;

        public PostRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Post FindPostByTitle(string title)
        {
            try
            {
                Post post = dbContext.posts.Where(post => post.title == title).FirstOrDefault();
                return post;
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }

        public Post FindPostByTitleAndNotId(Guid id, string title)
        {
            try
            {
                Post post = dbContext.posts.Where(post => post.title == title && post.id != id).FirstOrDefault();
                return post;
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }
    }
}
