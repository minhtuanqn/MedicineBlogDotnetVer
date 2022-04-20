using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Dto
{
    public class UpdatePostDTO
    {
        [Required(ErrorMessage = "Id can not be null")]
        public Guid id { get; set; }

        public string coverPhoto { get; set; }

        [Required(ErrorMessage = "Title can not be null")]
        public string title { get; set; }

        [Required(ErrorMessage = "Content can not be null")]
        public string content { get; set; }

        public string tagIds { get; set; }

    }
}
