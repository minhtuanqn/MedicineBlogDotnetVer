using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class CreateTopicDTO
    {
        [Required(ErrorMessage = "ID can not be null")]
        [StringLength(100, ErrorMessage = "Max length of topic is 100 characters")]
        public string name { get; set; }

        public string description { get; set; }

    }
}
