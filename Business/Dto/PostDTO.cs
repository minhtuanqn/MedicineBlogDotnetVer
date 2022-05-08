using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Business.Dto
{
    public class PostDTO
    {
        public Guid id { get; set; }

        public string coverPhoto { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public string createDate { get; set; }

        public Guid authorId { get; set; }

        public string authorName { get; set; }

        public string tagIds { get; set; }

        public Guid topicId { get; set; }

        public string topicName { get; set; }

        [JsonIgnore]
        public bool status { get; set; }

        public Dictionary<Guid, List<CommentDTO>> comments { get; set; }
    }
}
