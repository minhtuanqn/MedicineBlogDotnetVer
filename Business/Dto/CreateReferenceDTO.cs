using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class CreateReferenceDTO
    {
        [Required(ErrorMessage = "Name can not be null")]
        public string name { get; set; }

        public string description { get; set; }

        [Required(ErrorMessage = "Url can not be null")]
        public string url { get; set; }

        [Required(ErrorMessage = "Category can not be null")]
        public string categoryName { get; set; }

    }
}
