using Business.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface ITopicService
    {
        public Task<TopicDTO> FindTopicByIdAsync(Guid id);
        public Task<TopicDTO> CreateTopicAsync(CreateTopicDTO dto);
        public Task<TopicDTO> DeleteTopicByIdAsync(Guid id);
        public Task<TopicDTO> UpdateTopicAsync(UpdateTopicDTO dto);

        public Task<List<TopicDTO>> GetAllTopicAsync();
    }

}
