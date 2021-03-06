using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IReferenceRepository : IGenericRepository<Reference>
    {
        public Reference FindRefByName(string name);

        public Reference FindRefByNameAndNotId(Guid id, string name);
    }
}
