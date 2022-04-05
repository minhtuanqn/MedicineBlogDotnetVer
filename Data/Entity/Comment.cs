using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [Column("id")]
        public Guid id { get; set; }

        [Column("content")]
        public string content { get; set; }

        [Column("parentId")]
        public Guid parentId { get; set; }

        [Column("postId")]
        public Guid postId { get; set; }

        [Column("userId")]
        public Guid userId { get; set; }

        [Column("createdDate")]
        public string createdDate { get; set; }

        [Column("Status")]
        public bool status { get; set; }
    }
}
