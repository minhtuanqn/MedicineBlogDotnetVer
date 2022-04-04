using System;

namespace Business.Exceptions
{
    [Serializable]
    public class NotFoundEntityException : BusinessException
    {
        public NotFoundEntityException(string message)
            : base(message)
        {
        }
    }
}
