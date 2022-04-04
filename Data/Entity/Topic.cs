using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("Topic")]
    public class Topic
    {
        [Key]
        [Column("Id")]
        public Guid id { get; set; }

        [Column("Name")]
        public string name { get; set; }

        [Column("Description")]
        public string description { get; set; }

        [Column("Status")]
        public bool status { get; set; }
    }
}
