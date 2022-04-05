using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Dto
{
    public class UpdateBlogUserDTO
    {
        [Required(ErrorMessage = "Id can not be null")]
        public Guid id { get; set; }

        [DataType(dataType: DataType.PhoneNumber)]
        public string phone { get; set; }

        [Required(ErrorMessage = "Name can not be null")]
        [StringLength(100, ErrorMessage = "Max length of topic is 100 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Id can not be null")]
        public string role { get; set; }

    }
}
