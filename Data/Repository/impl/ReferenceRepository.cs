using Data.Database;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.impl
{
    public class ReferenceRepository : GenericRepository<Reference>, IReferenceRepository
    {
        private readonly AppDbContext dbContext;

        public ReferenceRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
