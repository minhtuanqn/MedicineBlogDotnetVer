using System;
using System.Text.Json.Serialization;

namespace Business.Dto
{
    public class BlogUserDTO
    {
        public Guid id { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string name { get; set; }

        public string role { get; set; }

        [JsonIgnore]
        public bool status { get; set; }
    }
}
