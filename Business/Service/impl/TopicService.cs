using Business.Dto;
using Business.Exceptions;
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

        public async Task<TopicDTO> CreateTopicAsync(CreateTopicDTO dto)
        {
            Topic existedTopic = topicRepository.FindTopicByName(dto.name);
            if(existedTopic != null)
            {
                throw new DuplicateEntityException("Duplicated name of topic");
            }
            Topic createdTopic = Mapper.GetMapper().Map<Topic>(dto);
            createdTopic.id = Guid.NewGuid();
            createdTopic.status = true;
            Topic insertedTopic = await topicRepository.AddAsync(createdTopic);
            return Mapper.GetMapper().Map<TopicDTO>(insertedTopic);
        }

        public async Task<TopicDTO> UpdateTopicAsync(UpdateTopicDTO dto)
        {
            Topic existedTopicId = await topicRepository.FindByIdAsync(dto.id);
            if(existedTopicId != null && existedTopicId.status)
            {
                Topic existTopicName = topicRepository.FindTopicByNameAndNotId(dto.id, dto.name);
                if(existTopicName == null)
                {
                    existedTopicId.name = dto.name;
                    existedTopicId.description = dto.description;
                    Topic updatedTopic = await topicRepository.UpdateAsync(existedTopicId);
                    return Mapper.GetMapper().Map<TopicDTO>(updatedTopic);
                }
                throw new DuplicateEntityException("Duplicated name of topic");
            }
            throw new NotFoundEntityException("Not found topic with id");
        }

        public async Task<TopicDTO> DeleteTopicByIdAsync(Guid id)
        {
            Topic existedTopic = await topicRepository.FindByIdAsync(id);
            if (existedTopic != null && existedTopic.status)
            {
                existedTopic.status = false;
                Topic deletedTopic = await topicRepository.UpdateAsync(existedTopic);
                return Mapper.GetMapper().Map<TopicDTO>(deletedTopic);
            }
            throw new NotFoundEntityException("Not found topic with id");
        }

        public async Task<TopicDTO> FindTopicByIdAsync(Guid id)
        {
            Topic topic = await topicRepository.FindByIdAsync(id);
            if (topic != null && topic.status)
            {
                return Mapper.GetMapper().Map<TopicDTO>(topic);
            }

            throw new NotFoundEntityException("Not found topic with id");
        }        
    }
}
