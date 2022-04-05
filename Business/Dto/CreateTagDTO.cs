using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class CreateTagDTO
    {
        [Required(ErrorMessage = "Name can not be null")]
        [StringLength(30, ErrorMessage = "Max length of topic is 30 characters")]
        public string name { get; set; }

        public string description { get; set; }

    }
}
