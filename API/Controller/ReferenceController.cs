using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controller
{
    [Route("api/references")]
    [ApiController]
    public class ReferenceController
    {
        private readonly IReferenceService referenceService;

        public ReferenceController(IReferenceService referenceService)
        {
            this.referenceService = referenceService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindRefById(Guid id)
        {
            ReferenceDTO existedDTO = await referenceService.FindRefByIdAsync(id);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("OK").Data(existedDTO).convertToJson();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRefById(Guid id)
        {
            ReferenceDTO dto = await referenceService.DeleteRefByIdAsync(id);
            return FactoryUtils.createResponseModel().StatusCode(200).Message("Deleted successfully").Data(dto).convertToJson();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRef(CreateReferenceDTO dto)
        {
            ReferenceDTO createdRef = await referenceService.CreateRefAsync(dto);
            return FactoryUtils.createResponseModel().Data(createdRef).StatusCode(200).Message("Created successfully").convertToJson();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRef(UpdateReferenceDTO dto)
        {
            ReferenceDTO updatedRef = await referenceService.UpdateRefAsync(dto);
            return FactoryUtils.createResponseModel().Data(updatedRef).StatusCode(200).Message("Update successfully").convertToJson();
        }
    }
}
