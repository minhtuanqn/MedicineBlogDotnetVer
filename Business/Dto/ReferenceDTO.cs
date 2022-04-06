using System;
using System.Text.Json.Serialization;

namespace Business.Dto
{
    public class ReferenceDTO
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string url { get; set; }

        public string categoryName { get; set; }

        [JsonIgnore]
        public bool status { get; set; }
    }
}
