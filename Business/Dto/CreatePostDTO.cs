using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Dto
{
    public class CreatePostDTO
    {
        [Required(ErrorMessage = "Title can not be null")]
        public string title { get; set; }

        [Required(ErrorMessage = "Content can not be null")]
        public string content { get; set; }

        public string tagIds { get; set; }

        [Required(ErrorMessage = "Topic id can not be null")]
        public Guid topicId { get; set; }

    }
}
