using Business.Dto;
using System;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface ICommentService
    {
        public Task<CommentDTO> FindCommentByIdAsync(Guid id);
        public Task<CommentDTO> CreateCommentAsync(CreateCommentDTO dto);
        public Task<CommentDTO> DeleteCommentByIdAsync(Guid id);
        public Task<CommentDTO> UpdateCommentAsync(UpdateCommentDTO dto);
    }
}
