using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controller
{
    [Route("api/topics")]
    [ApiController]
    public class TopicController
    {
        private readonly ITopicService topicService;

        public TopicController(ITopicService topicService)
        {
            this.topicService = topicService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindTopicById(Guid id)
        {
            try
            {
                TopicDTO existedDTO = await topicService.FindTopicByIdAsync(id);
                if(existedDTO != null)
                {
                    return FactoryUtils.createResponseModel().Status(200).Message("OK").Data(existedDTO).convertToJson();
                }
                return FactoryUtils.createResponseModel().Status(400).Message("Not found any result").Data(existedDTO).convertToJson();
            }
            catch (Exception e)
            {
                return FactoryUtils.createResponseModel().Status(400).Message("Error").Data(null).convertToJson();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopicById(Guid id)
        {
            try
            {
                TopicDTO dto = await topicService.DeleteTopicByIdAsync(id);
                if (dto != null)
                {
                    return FactoryUtils.createResponseModel().Status(200).Message("Deleted successfully").Data(dto).convertToJson();
                }
                return FactoryUtils.createResponseModel().Status(400).Message("Not found topic").Data(dto).convertToJson();
            }
            catch (Exception e)
            {
                return FactoryUtils.createResponseModel().Status(400).Message("Error").Data(null).convertToJson();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic(TopicDTO dto)
        {
            try
            {
                TopicDTO createdTopic = await topicService.CreateTopicAsync(dto);
                if(createdTopic != null)
                {
                    return FactoryUtils.createResponseModel().Data(createdTopic).Status(200).Message("Created successfully").convertToJson();
                }
                return FactoryUtils.createResponseModel().Data(createdTopic).Status(400).Message("Bad request").convertToJson();
            }
            catch (Exception e)
            {
                return FactoryUtils.createResponseModel().Data(null).Status(400).Message("Error").convertToJson();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTopic(TopicDTO dto)
        {
            try
            {
                TopicDTO updatedTopic = await topicService.UpdateTopicAsync(dto);
                if (updatedTopic != null)
                {
                    return FactoryUtils.createResponseModel().Data(updatedTopic).Status(200).Message("Update successfully").convertToJson();
                }
                return FactoryUtils.createResponseModel().Data(updatedTopic).Status(400).Message("Bad request").convertToJson();
            }
            catch (Exception e)
            {
                return FactoryUtils.createResponseModel().Data(null).Status(400).Message("Error").convertToJson();
            }
        }
    }
}
