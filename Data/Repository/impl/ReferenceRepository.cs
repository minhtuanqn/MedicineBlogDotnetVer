using Data.Database;
using Data.Entity;
using Data.Exceptions;
using System;
using System.Linq;

namespace Data.Repository.impl
{
    public class ReferenceRepository : GenericRepository<Reference>, IReferenceRepository
    {
        private readonly AppDbContext dbContext;

        public ReferenceRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Reference FindRefByName(string name)
        {
            try
            {
                Reference existedRef = dbContext.references.Where(reference => reference.name == name).FirstOrDefault();
                return existedRef;
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }

        public Reference FindRefByNameAndNotId(Guid id, string name)
        {
            try
            {
                Reference existedRef = dbContext.references.Where(reference => reference.name == name && reference.id != id).FirstOrDefault();
                return existedRef;
            }
            catch (Exception e)
            {
                throw new SQLException(e.Message);
            }
        }
    }
}
