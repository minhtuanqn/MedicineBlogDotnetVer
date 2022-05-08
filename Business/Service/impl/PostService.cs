using Business.Dto;
using Business.Exceptions;
using Business.Utils;
using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Service.impl
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository;
        private ITopicRepository topicRepository;
        private ICommentRepository commentRepository;

        public PostService(IPostRepository postRepository, ITopicRepository topicRepository, ICommentRepository commentRepository)
        {
            this.postRepository = postRepository;
            this.topicRepository = topicRepository;
            this.commentRepository = commentRepository;
        }

        public async Task<PostDTO> CreatePostAsync(CreatePostDTO dto)
        {
            Topic existedTopic = await topicRepository.FindByIdAsync(dto.topicId);
            if (existedTopic == null) throw new NotFoundEntityException("Not found topic");
            Post existedPost = postRepository.FindPostByTitle(dto.title);
            if (existedPost != null) throw new DuplicateEntityException("Duplicated title of post");

            Post createdPost = Mapper.GetMapper().Map<Post>(dto);
            createdPost.id = Guid.NewGuid();
            createdPost.status = true;
            createdPost.createDate = DateTime.Now.ToString();
            Post insertedPost = await postRepository.AddAsync(createdPost);
            insertedPost.topicName = existedTopic.name;
            return Mapper.GetMapper().Map<PostDTO>(insertedPost);
        }

        public async Task<PostDTO> DeletePostByIdAsync(Guid id)
        {
            Post existedPost = await postRepository.FindByIdAsync(id);
            if (existedPost != null && existedPost.status)
            {
                existedPost.status = false;
                Post deletedPost = await postRepository.UpdateAsync(existedPost);
                return Mapper.GetMapper().Map<PostDTO>(deletedPost);
            }
            throw new NotFoundEntityException("Not found post with id");
        }

        public async Task<PostDTO> FindPostByIdAsync(Guid id)
        {
            Post post = await postRepository.FindByIdAsync(id);
            if (post != null && post.status)
            {
                PostDTO postDTO = Mapper.GetMapper().Map<PostDTO>(post);
                List<Comment> rootCmts = await commentRepository.GetAllRootCmtByPostIdAsync(id);
                if(rootCmts != null)
                {
                    Console.WriteLine(rootCmts.Count);
                    Dictionary<Guid, List<CommentDTO>> cmtDtos = new Dictionary<Guid, List<CommentDTO>>();
                    foreach (Comment rootCmt in rootCmts)
                    {
                        List<Comment> subCmts = await commentRepository.GetAllCmtByRootIdAsync(rootCmt.id);
                        List<CommentDTO> dtosDict = new List<CommentDTO>();
                        if (subCmts != null)
                        {
                            foreach (Comment subCmt in subCmts)
                            {
                                dtosDict.Add(Mapper.GetMapper().Map<CommentDTO>(subCmt));
                            }    
                        }
                        List<CommentDTO> sortedList = dtosDict.OrderBy(o => o.createdDate).ToList();
                        cmtDtos.Add(rootCmt.id, sortedList);
                    }
                    postDTO.comments = cmtDtos;
                }
                return postDTO;
            }

            throw new NotFoundEntityException("Not found post with id");
        }

        public async Task<List<PostDTO>> GetAllPostAsync()
        {
            IEnumerable<Post> postsEnum = await postRepository.GetAllAsync();
            List<PostDTO> dtos = new List<PostDTO>();
            foreach(Post post in postsEnum)
            {
                if(post.status)
                {
                    dtos.Add(Mapper.GetMapper().Map<PostDTO>(post));
                }
            }
            return dtos;
        }

        public async Task<List<PostDTO>> GetAllPostByTopicNameAsync(string topicName)
        {
            List<Post> posts = await postRepository.FindPostByTopicNameAsync(topicName);
            List<PostDTO> dtos = new List<PostDTO>();
            foreach (Post post in posts)
            {
                if (post.status)
                {
                    dtos.Add(Mapper.GetMapper().Map<PostDTO>(post));
                }
            }
            return dtos;
        }

        public async Task<PostDTO> UpdatePostAsync(UpdatePostDTO dto)
        {
            Post existedPostId = await postRepository.FindByIdAsync(dto.id);
            if (existedPostId != null && existedPostId.status)
            {
                Post existPostTitle = postRepository.FindPostByTitleAndNotId(dto.id, dto.title);
                if (existPostTitle == null)
                {
                    existedPostId.title = dto.title;
                    existedPostId.content = dto.content;
                    existedPostId.tagIds = dto.tagIds;
                    Post updatedPost = await postRepository.UpdateAsync(existedPostId);
                    return Mapper.GetMapper().Map<PostDTO>(updatedPost);
                }
                throw new DuplicateEntityException("Duplicated title of post");
            }
            throw new NotFoundEntityException("Not found post with id");
        }
    }
}
