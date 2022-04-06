using System;

namespace Business.Dto
{
    public class CommentDTO
    {
        public Guid id { get; set; }

        public string content { get; set; }

        public Guid parentId { get; set; }

        public Guid postId { get; set; }

        public Guid userId { get; set; }

        public string createdDate { get; set; }

        public bool status { get; set; }
    }
}
