using Data.Database;
using Data.Entity;
using Data.Exceptions;
using System;
using System.Linq;

namespace Data.Repository.impl
{
    public class TopicRepository : GenericRepository<Topic>,ITopicRepository
    {
        private readonly AppDbContext dbContext;

        public TopicRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Topic FindTopicByNameAndNotId(Guid id, string name)
        {
            try
            {
                Topic topic = dbContext.topics.Where(topic => topic.name == name && topic.id != id).FirstOrDefault();
                return topic;
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }

        public Topic FindTopicByName(string name)
        {
            try
            {
                Topic topic = dbContext.topics.Where(topic => topic.name == name).FirstOrDefault();
                return topic;
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }
    }
}
