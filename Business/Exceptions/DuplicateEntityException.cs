using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    [Serializable]
    public class DuplicateEntityException : BusinessException
    {
        public DuplicateEntityException(string message)
            : base(message)
        {
        }

    }
}
