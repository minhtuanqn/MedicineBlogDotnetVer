using Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ITopicRepository : IGenericRepository<Topic>
    {
        public Topic FindTopicByName(string name);

        public Topic FindTopicByNameAndNotId(Guid id, string name);
    }
}
