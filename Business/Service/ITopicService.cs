using Business.Dto;
using System;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface ITopicService
    {
        public Task<TopicDTO> FindTopicByIdAsync(Guid id);
        public Task<TopicDTO> CreateTopicAsync(TopicDTO dto);
        public Task<TopicDTO> DeleteTopicByIdAsync(Guid id);
        public Task<TopicDTO> UpdateTopicAsync(TopicDTO dto);
        
    }

}
