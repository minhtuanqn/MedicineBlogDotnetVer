using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [Column("id")]
        public Guid id { get; set; }

        [Column("coverPhoto")]
        public string coverPhoto { get; set; }

        [Column("title")]
        public string title { get; set; }

        [Column("content")]
        public string content { get; set; }

        [Column("createDate")]
        public string createDate { get; set; }

        [Column("authorId")]
        public Guid authorId { get; set; }

        [Column("authorName")]
        public string authorName { get; set; }

        [Column("tagIds")]
        public string tagIds { get; set; }

        [Column("topicId")]
        public Guid topicId { get; set; }

        [Column("Status")]
        public bool status { get; set; }
    }
}
