using System.Text.Json.Serialization;

namespace Business.Dto
{
    public class TagDTO
    {
        public string name { get; set; }

        public string description { get; set; }

        [JsonIgnore]
        public bool status { get; set; }
    }
}
