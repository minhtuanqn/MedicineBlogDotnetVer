using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class CreateBlogUserDTO
    {
        [Required(ErrorMessage = "Email can not be null")]
        [DataType(dataType: DataType.EmailAddress)]
        public string email { get; set; }

        [DataType(dataType: DataType.PhoneNumber)]
        public string phone { get; set; }

        [Required(ErrorMessage = "Name can not be null")]
        [StringLength(100, ErrorMessage = "Max length of user name is 100 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Role can not be null")]
        public string role { get; set; }

    }
}
