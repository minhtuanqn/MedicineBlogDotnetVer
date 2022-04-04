using Business.Dto;
using Business.Utils;
using Data.Entity;
using Data.Repository;
using System;
using System.Threading.Tasks;

namespace Business.Service.impl
{
    public class TopicService : ITopicService
    {
        private ITopicRepository topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            this.topicRepository = topicRepository;
        }

        public async Task<TopicDTO> CreateTopicAsync(TopicDTO dto)
        {
            Topic topic = Mapper.GetMapper().Map<Topic>(dto);
            topic.id = Guid.NewGuid();
            topic.status = true;
            Topic insertedTopic = await topicRepository.AddAsync(topic);
            return Mapper.GetMapper().Map<TopicDTO>(insertedTopic);
        }

        public async Task<TopicDTO> UpdateTopicAsync(TopicDTO dto)
        {
            Topic existedTopic = await topicRepository.FindByIdAsync(dto.id);
            if(existedTopic != null)
            {
                existedTopic.name = dto.name;
                existedTopic.description = dto.description;
                Topic updatedTopic = await topicRepository.UpdateAsync(existedTopic);
                return Mapper.GetMapper().Map<TopicDTO>(updatedTopic);
            }
            return null;   
        }

        public async Task<TopicDTO> DeleteTopicByIdAsync(Guid id)
        {
            Topic existedTopic = await topicRepository.FindByIdAsync(id);
            if (existedTopic != null)
            {
                existedTopic.status = false;
                Topic deletedTopic = await topicRepository.UpdateAsync(existedTopic);
                return Mapper.GetMapper().Map<TopicDTO>(deletedTopic);
            }
            return null;
        }

        public async Task<TopicDTO> FindTopicByIdAsync(Guid id)
        {
            Topic topic = await topicRepository.FindByIdAsync(id);
            if (topic != null)
            {
                TopicDTO dto = Mapper.GetMapper().Map<TopicDTO>(topic);
                return dto;
            }
            
            return null;
        }        
    }
}
