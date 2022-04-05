using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("BlogUser")]
    public class BlogUser
    {
        [Key]
        [Column("id")]
        public Guid id { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("phone")]
        public string phone { get; set; }

        [Column("name")]
        public string name { get; set; }

        [Column("role")]
        public string role { get; set; }

        [Column("status")]
        public bool status { get; set; }
    }
}
