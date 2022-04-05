using System;

namespace Business.Exceptions
{
    [Serializable]
    public class NotFoundEntityException : Exception
    {
        public string MessageDetail { get; set; }

        public object Errors { get; set; }

        public string message { get; set; }

        public NotFoundEntityException(string message, string messageDetail = null, object errors = null)
            : base(message)
        {
            MessageDetail = messageDetail;
            Errors = errors;
        }

        public NotFoundEntityException()
        {
        }

        public NotFoundEntityException(string message)
            : base(message)
        {
            this.message = message;
        }


        protected NotFoundEntityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public NotFoundEntityException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}
