using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        [Column("name")]
        public string name { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("Status")]
        public bool status { get; set; }
    }
}
