using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controller
{
    [Route("api/posts")]
    [ApiController]
    public class PostController
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindPostById(Guid id)
        {
            PostDTO existedPost = await postService.FindPostByIdAsync(id);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("OK").Data(existedPost).convertToJson();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostById(Guid id)
        {
            PostDTO deletedPost = await postService.DeletePostByIdAsync(id);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("Deleted successfully").Data(deletedPost).convertToJson();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic(CreatePostDTO dto)
        {
            PostDTO createdPost = await postService.CreatePostAsync(dto);
            return FactoryUtils.createResponseModel().Data(createdPost).StatusCode(200).Message("Created successfully").convertToJson();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTopic(UpdatePostDTO dto)
        {
            PostDTO updatedPost = await postService.UpdatePostAsync(dto);
            return FactoryUtils.createResponseModel().Data(updatedPost).StatusCode(200).Message("Update successfully").convertToJson();
        }

        [HttpGet()]
        public async Task<IActionResult> SearchPosts()
        {
            List<PostDTO> existedPosts = await postService.GetAllPostAsync();
            return FactoryUtils.createResponseModel().StatusCode(200).Message("OK").Data(existedPosts).convertToJson();
        }
    }
}
