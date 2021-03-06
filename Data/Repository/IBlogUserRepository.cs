using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IBlogUserRepository : IGenericRepository<BlogUser>
    {
        public BlogUser FindUserByEmail(string email);
    }
}
