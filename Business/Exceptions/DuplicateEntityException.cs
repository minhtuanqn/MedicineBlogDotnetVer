using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    [Serializable]
    public class DuplicateEntityException : Exception
    {
        public string MessageDetail { get; set; }

        public object Errors { get; set; }

        public string message { get; set; }

        public DuplicateEntityException(string message, string messageDetail = null, object errors = null)
            : base(message)
        {
            MessageDetail = messageDetail;
            Errors = errors;
        }

        public DuplicateEntityException()
        {
        }

        public DuplicateEntityException(string message)
            : base(message)
        {
            this.message = message;
        }


        protected DuplicateEntityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public DuplicateEntityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
