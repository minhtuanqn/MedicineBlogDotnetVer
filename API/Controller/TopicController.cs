using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controller
{
    [Route("api/topics")]
    [ApiController]
    public class TopicController
    {
        private readonly ITopicService topicService;
        private readonly IPostService postService;

        public TopicController(ITopicService topicService, IPostService postService)
        {
            this.topicService = topicService;
            this.postService = postService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindTopicById(Guid id)
        {
            TopicDTO existedDTO = await topicService.FindTopicByIdAsync(id);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("OK").Data(existedDTO).convertToJson();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopicById(Guid id)
        {
            TopicDTO dto = await topicService.DeleteTopicByIdAsync(id);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("Deleted successfully").Data(dto).convertToJson();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic(CreateTopicDTO dto)
        {
            TopicDTO createdTopic = await topicService.CreateTopicAsync(dto);
            return FactoryUtils.createResponseModel().Data(createdTopic).StatusCode(200).Message("Created successfully").convertToJson();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTopic(UpdateTopicDTO dto)
        {
            TopicDTO updatedTopic = await topicService.UpdateTopicAsync(dto);
            return FactoryUtils.createResponseModel().Data(updatedTopic).StatusCode(200).Message("Update successfully").convertToJson();
        }

        [HttpGet()]
        public async Task<IActionResult> SearchTags()
        {
            List<TopicDTO> existedTopics = await topicService.GetAllTopicAsync();
            return FactoryUtils.createResponseModel().StatusCode(200).Message("OK").Data(existedTopics).convertToJson();
        }


        [HttpGet("{topicName}/posts/")]
        public async Task<IActionResult> SearchPostsByTopicName(string topicName)
        {
            List<PostDTO> existedPosts = await postService.GetAllPostByTopicNameAsync(topicName);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("OK").Data(existedPosts).convertToJson();
        }
    }
}
