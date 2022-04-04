using AutoMapper;
using Business.Dto;
using Data.Entity;

namespace Business.Utils
{
    public class Mapper
    {
        public static IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Topic, TopicDTO>();
                cfg.CreateMap<TopicDTO, Topic>();
            });
            return configuration.CreateMapper();
        }
    }
}
