using Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IPostService
    {
        public Task<PostDTO> FindPostByIdAsync(Guid id);
        public Task<PostDTO> CreatePostAsync(CreatePostDTO dto);
        public Task<PostDTO> DeletePostByIdAsync(Guid id);
        public Task<PostDTO> UpdatePostAsync(UpdatePostDTO dto);
        public Task<List<PostDTO>> GetAllPostAsync();
    }
}
