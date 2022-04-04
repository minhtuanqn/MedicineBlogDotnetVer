using System;

namespace Data.Exceptions
{
    public class SQLException : Exception
    {
        public string MessageDetail { get; set; }

        public object Errors { get; set; }

        public string message { get; set; }

        public SQLException(string message, string messageDetail = null, object errors = null)
            : base(message)
        {
            MessageDetail = messageDetail;
            Errors = errors;
        }

        public SQLException()
        {
        }

        public SQLException(string message)
            : base(message)
        {
        }


        protected SQLException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public SQLException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
