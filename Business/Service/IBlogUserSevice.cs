using Business.Dto;
using System;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IBlogUserSevice
    {
        public Task<BlogUserDTO> FindUserByIdAsync(Guid id);
        public Task<BlogUserDTO> CreateUserAsync(CreateBlogUserDTO dto);
        public Task<BlogUserDTO> DeleteUserByIdAsync(Guid id);
        public Task<BlogUserDTO> UpdateUserAsync(UpdateBlogUserDTO dto);
    }
}
