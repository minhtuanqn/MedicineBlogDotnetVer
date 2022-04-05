using Business.Dto;
using Business.Exceptions;
using Business.Utils;
using Data.Entity;
using Data.Repository;
using System;
using System.Threading.Tasks;

namespace Business.Service.impl
{
    public class BlogUserService : IBlogUserSevice
    {
        private IBlogUserRepository blogUserRepository;

        public BlogUserService(IBlogUserRepository blogUserRepository)
        {
            this.blogUserRepository = blogUserRepository;
        }

        public async Task<BlogUserDTO> CreateUserAsync(CreateBlogUserDTO dto)
        {
            BlogUser existedUser = blogUserRepository.FindUserByEmail(dto.email);
            if (existedUser != null) throw new DuplicateEntityException("Duplicated email of user");

            BlogUser createdUser = Mapper.GetMapper().Map<BlogUser>(dto);
            createdUser.id = Guid.NewGuid();
            createdUser.status = true;
            BlogUser insertedUSer = await blogUserRepository.AddAsync(createdUser);
            return Mapper.GetMapper().Map<BlogUserDTO>(insertedUSer);
        }

        public async Task<BlogUserDTO> DeleteUserByIdAsync(Guid id)
        {
            BlogUser existedUser = await blogUserRepository.FindByIdAsync(id);
            if (existedUser != null && existedUser.status)
            {
                existedUser.status = false;
                BlogUser deletedUser = await blogUserRepository.UpdateAsync(existedUser);
                return Mapper.GetMapper().Map<BlogUserDTO>(deletedUser);
            }
            throw new NotFoundEntityException("Not found user with id");
        }

        public async Task<BlogUserDTO> FindUserByIdAsync(Guid id)
        {
            BlogUser user = await blogUserRepository.FindByIdAsync(id);
            if (user != null && user.status)
            {
                return Mapper.GetMapper().Map<BlogUserDTO>(user);
            }

            throw new NotFoundEntityException("Not found user with id");
        }

        public async Task<BlogUserDTO> UpdateUserAsync(UpdateBlogUserDTO dto)
        {
            BlogUser existedUser = await blogUserRepository.FindByIdAsync(dto.id);
            if (existedUser != null && existedUser.status)
            {
                existedUser.phone = dto.phone;
                existedUser.name = dto.name;
                existedUser.role = dto.role;
                BlogUser updatedUser = await blogUserRepository.UpdateAsync(existedUser);
                return Mapper.GetMapper().Map<BlogUserDTO>(updatedUser);
            }
            throw new NotFoundEntityException("Not found user with id");
        }
    }
}
