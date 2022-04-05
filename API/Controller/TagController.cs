using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controller
{
    [Route("api/tags")]
    [ApiController]
    public class TagController
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet("{name}")]
        public IActionResult FindTagByName(string name)
        {
            TagDTO existedDTO = tagService.FindTagByName(name);
            return FactoryUtils.createResponseModel().Message("OK").Data(existedDTO).StatusCode(200).convertToJson();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteTagByName(string name)
        {
            TagDTO dto = await tagService.DeleteTagByNameAsync(name);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("Deleted successfully").Data(dto).convertToJson();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagDTO dto)
        {
            TagDTO createdTag = await tagService.CreateTagAsync(dto);
            return FactoryUtils.createResponseModel().Data(createdTag).StatusCode(200).Message("Created successfully").convertToJson();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagDTO dto)
        {
            TagDTO updatedTag = await tagService.UpdateTagAsync(dto);
            return FactoryUtils.createResponseModel().Data(updatedTag).StatusCode(200).Message("Update successfully").convertToJson();
        }
    }
}
