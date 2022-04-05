using Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface ITagService
    {
        public TagDTO FindTagByName(string name);
        public Task<TagDTO> CreateTagAsync(CreateTagDTO dto);
        public Task<TagDTO> DeleteTagByNameAsync(string name);
        public Task<TagDTO> UpdateTagAsync(UpdateTagDTO dto);
    }
}
