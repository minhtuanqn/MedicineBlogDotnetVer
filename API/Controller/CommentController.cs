using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controller
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindCommentById(Guid id)
        {
            CommentDTO existedDTO = await commentService.FindCommentByIdAsync(id);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("OK").Data(existedDTO).convertToJson();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentById(Guid id)
        {
            CommentDTO dto = await commentService.DeleteCommentByIdAsync(id);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("Deleted successfully").Data(dto).convertToJson();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDTO dto)
        {
            CommentDTO createdComment = await commentService.CreateCommentAsync(dto);
            return FactoryUtils.createResponseModel().Data(createdComment).StatusCode(200).Message("Created successfully").convertToJson();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentDTO dto)
        {
            CommentDTO updatedComment = await commentService.UpdateCommentAsync(dto);
            return FactoryUtils.createResponseModel().Data(updatedComment).StatusCode(200).Message("Update successfully").convertToJson();
        }
    }
}
