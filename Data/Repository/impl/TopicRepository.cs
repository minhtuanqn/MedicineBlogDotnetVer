using Data.Database;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.impl
{
    public class TopicRepository : GenericRepository<Topic>,ITopicRepository
    {
        private readonly AppDbContext dbContext;

        public TopicRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
