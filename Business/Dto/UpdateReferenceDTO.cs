using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Dto
{
    public class UpdateReferenceDTO
    {
        [Required(ErrorMessage = "Id can not be null")]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Name can not be null")]
        public string name { get; set; }

        public string description { get; set; }

        [Required(ErrorMessage = "Url can not be null")]
        public string url { get; set; }

        [Required(ErrorMessage = "Category can not be null")]
        public string categoryName { get; set; }

    }
}
