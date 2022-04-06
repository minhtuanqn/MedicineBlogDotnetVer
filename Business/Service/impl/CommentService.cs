using Business.Dto;
using Business.Exceptions;
using Business.Utils;
using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.impl
{
    public class CommentService : ICommentService
    {
        private ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task<CommentDTO> CreateCommentAsync(CreateCommentDTO dto)
        {
            Comment createdComment = Mapper.GetMapper().Map<Comment>(dto);
            createdComment.id = Guid.NewGuid();
            createdComment.status = true;
            createdComment.createdDate = DateTime.Now.ToString();
            Comment insertedComment = await commentRepository.AddAsync(createdComment);
            return Mapper.GetMapper().Map<CommentDTO>(insertedComment);
        }

        public async Task<CommentDTO> DeleteCommentByIdAsync(Guid id)
        {
            Comment existedComment = await commentRepository.FindByIdAsync(id);
            if (existedComment != null && existedComment.status)
            {
                existedComment.status = false;
                Comment deletedComment = await commentRepository.UpdateAsync(existedComment);
                return Mapper.GetMapper().Map<CommentDTO>(deletedComment);
            }
            throw new NotFoundEntityException("Not found comment with id");
        }

        public async Task<CommentDTO> FindCommentByIdAsync(Guid id)
        {
            Comment comment = await commentRepository.FindByIdAsync(id);
            if (comment != null && comment.status)
            {
                return Mapper.GetMapper().Map<CommentDTO>(comment);
            }

            throw new NotFoundEntityException("Not found comment with id"); 
        }

        public async Task<CommentDTO> UpdateCommentAsync(UpdateCommentDTO dto)
        {
            Comment existedComment = await commentRepository.FindByIdAsync(dto.id);
            if (existedComment != null && existedComment.status)
            {
                existedComment.content = dto.content;
                Comment updatedComment = await commentRepository.UpdateAsync(existedComment);
                return Mapper.GetMapper().Map<CommentDTO>(updatedComment);
            }
            throw new NotFoundEntityException("Not found comment with id");
        }
    }
}
