using System;

namespace Business.Dto
{
    public class TopicDTO
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool status { get; set; }
    }
}
