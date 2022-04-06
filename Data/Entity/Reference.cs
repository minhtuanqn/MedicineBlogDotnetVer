using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("Reference")]
    public class Reference
    {
        [Key]
        [Column("Id")]
        public Guid id { get; set; }

        [Column("Name")]
        public string name { get; set; }

        [Column("Description")]
        public string description { get; set; }

        [Column("Url")]
        public string url { get; set; }

        [Column("CategoryName")]
        public string categoryName { get; set; }

        [Column("Status")]
        public bool status { get; set; }
    }
}
