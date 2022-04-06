using Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IReferenceService
    {
        public Task<ReferenceDTO> FindRefByIdAsync(Guid id);
        public Task<ReferenceDTO> CreateRefAsync(CreateReferenceDTO dto);
        public Task<ReferenceDTO> DeleteRefByIdAsync(Guid id);
        public Task<ReferenceDTO> UpdateRefAsync(UpdateReferenceDTO dto);
    }
}
