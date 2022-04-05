using System.ComponentModel.DataAnnotations;

namespace Business.Dto
{
    public class UpdateTagDTO
    {
        [Required(ErrorMessage = "Name can not be null")]
        public string name { get; set; }

        public string description { get; set; }

    }
}
