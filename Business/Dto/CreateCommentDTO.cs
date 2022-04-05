using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class CreateCommentDTO
    {
        [Required(ErrorMessage = "Content can not be null")]
        public string content { get; set; }

        public Guid parentId { get; set; }

        [Required(ErrorMessage = "Post id can not be null")]
        public Guid postId { get; set; }

        [Required(ErrorMessage = "User id can not be null")]
        public Guid userId { get; set; }

    }
}
