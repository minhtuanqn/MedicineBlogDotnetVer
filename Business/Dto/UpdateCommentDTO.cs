using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Dto
{
    public class UpdateCommentDTO
    {
        [Required(ErrorMessage = "Id can not be null")]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Content can not be null")]
        public string content { get; set; }

    }
}
