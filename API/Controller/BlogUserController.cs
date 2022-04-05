using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controller
{
    [Route("api/users")]
    [ApiController]
    public class BlogUserController
    {
        private readonly IBlogUserSevice blogUserSevice;

        public BlogUserController(IBlogUserSevice blogUserSevice)
        {
            this.blogUserSevice = blogUserSevice;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindUserById(Guid id)
        {
            BlogUserDTO existedUser = await blogUserSevice.FindUserByIdAsync(id);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("OK").Data(existedUser).convertToJson();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            BlogUserDTO deletedUser = await blogUserSevice.DeleteUserByIdAsync(id);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("Deleted successfully").Data(deletedUser).convertToJson();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateBlogUserDTO dto)
        {
            BlogUserDTO createUser = await blogUserSevice.CreateUserAsync(dto);
            return FactoryUtils.createResponseModel().Data(createUser).StatusCode(200).Message("Created successfully").convertToJson();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTopic(UpdateBlogUserDTO dto)
        {
            BlogUserDTO updatedUser = await blogUserSevice.UpdateUserAsync(dto);
            return FactoryUtils.createResponseModel().Data(updatedUser).StatusCode(200).Message("Update successfully").convertToJson();
        }
    }
}
