using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class BusinessException : Exception
    {
        public string MessageDetail { get; set; }

        public object Errors { get; set; }

        public string message { get; set; }

        public BusinessException(string message, string messageDetail = null, object errors = null)
            : base(message)
        {
            MessageDetail = messageDetail;
            Errors = errors;
        }

        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }


        protected BusinessException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
