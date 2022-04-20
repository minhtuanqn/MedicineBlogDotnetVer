using Business.Dto;
using Business.Exceptions;
using Business.Utils;
using Data.Entity;
using Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service.impl
{
    public class TagService : ITagService
    {
        private ITagRepository tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public async Task<TagDTO> CreateTagAsync(CreateTagDTO dto)
        {
            Tag existedTag = tagRepository.FindTagByName(dto.name);
            if (existedTag != null) throw new DuplicateEntityException("Duplicated name of tag");

            Tag createdTag = Mapper.GetMapper().Map<Tag>(dto);
            createdTag.status = true;
            Tag insertedTag = await tagRepository.AddAsync(createdTag);
            return Mapper.GetMapper().Map<TagDTO>(insertedTag);
        }

        public async Task<TagDTO> DeleteTagByNameAsync(string name)
        {
            Tag existedTag = tagRepository.FindTagByName(name);
            if (existedTag != null && existedTag.status)
            {
                existedTag.status = false;
                Tag deletedTag = await tagRepository.UpdateAsync(existedTag);
                return Mapper.GetMapper().Map<TagDTO>(deletedTag);
            }
            throw new NotFoundEntityException("Not found tag with name");
        }

        public async Task<TagDTO> FindTagByName(string name)
        {
            Tag tag = tagRepository.FindTagByName(name);
            if (tag != null && tag.status)
            {
                return Mapper.GetMapper().Map<TagDTO>(tag);
            }

            throw new NotFoundEntityException("Not found tag with name");
        }

        public async Task<TagDTO> UpdateTagAsync(UpdateTagDTO dto)
        {
            Tag existedTag = tagRepository.FindTagByName(dto.name);
            if (existedTag != null && existedTag.status)
            {
                existedTag.description = dto.description;
                Tag updatedTag = await tagRepository.UpdateAsync(existedTag);
                return Mapper.GetMapper().Map<TagDTO>(updatedTag);
            }
            throw new NotFoundEntityException("Not found tag with name");
        }

        public async Task<List<TagDTO>> GetAllTagAsync()
        {
            IEnumerable<Tag> tagsEnum = await tagRepository.GetAllAsync();
            List<TagDTO> dtos = new List<TagDTO>();
            foreach (Tag tag in tagsEnum)
            {
                if(tag.status)
                {
                    dtos.Add(Mapper.GetMapper().Map<TagDTO>(tag));
                }
            }
            return dtos;
        }
    }
}
