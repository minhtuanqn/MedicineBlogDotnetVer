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
                cfg.CreateMap<CreateTopicDTO, Topic>();
                cfg.CreateMap<UpdateTopicDTO, Topic>();
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();
                cfg.CreateMap<CreatePostDTO, Post>();
                cfg.CreateMap<UpdatePostDTO, Post>();
                cfg.CreateMap<Tag, TagDTO>();
                cfg.CreateMap<TagDTO, Tag>();
                cfg.CreateMap<CreateTagDTO, Tag>();
                cfg.CreateMap<UpdateTagDTO, Tag>();
                cfg.CreateMap<BlogUser, BlogUserDTO>();
                cfg.CreateMap<BlogUserDTO, BlogUser>();
                cfg.CreateMap<CreateBlogUserDTO, BlogUser>();
                cfg.CreateMap<UpdateBlogUserDTO, BlogUser>();
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<CommentDTO, Comment>();
                cfg.CreateMap<CreateCommentDTO, Comment>();
                cfg.CreateMap<UpdateCommentDTO, Comment>();
                cfg.CreateMap<Reference, ReferenceDTO>();
                cfg.CreateMap<ReferenceDTO, Reference>();
                cfg.CreateMap<CreateReferenceDTO, Reference>();
                cfg.CreateMap<UpdateReferenceDTO, Reference>();
            });
            return configuration.CreateMapper();
        }
    }
}
