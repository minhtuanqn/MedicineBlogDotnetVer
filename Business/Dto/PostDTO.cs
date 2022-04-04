using System;
using System.Text.Json.Serialization;

namespace Business.Dto
{
    public class PostDTO
    {
        public Guid id { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public string createDate { get; set; }

        public string tagIds { get; set; }

        public Guid topicId { get; set; }

        [JsonIgnore]
        public bool status { get; set; }
    }
}
