using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Dto
{
    public class UpdateTopicDTO
    {
        [Required(ErrorMessage = "ID can not be null")]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Name can not be null")]
        [StringLength(100, ErrorMessage = "Max length of topic is 100 characters")]
        public string name { get; set; }

        public string description { get; set; }
    }
}
