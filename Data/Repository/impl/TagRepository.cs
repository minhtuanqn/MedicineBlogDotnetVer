using Data.Database;
using Data.Entity;
using Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.impl
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        private readonly AppDbContext dbContext;

        public TagRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Tag FindTagByName(string name)
        {
            try
            {
                Tag tag = dbContext.tags.Where(tag => tag.name == name).FirstOrDefault();
                return tag;
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }
    }
}
