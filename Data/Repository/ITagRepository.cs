using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        public Tag FindTagByName(string name);

        public Tag FindTagById(string id);
    }
}
