using Business.Dto;
using Business.Exceptions;
using Business.Utils;
using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.impl
{
    public class ReferenceService : IReferenceService
    {
        private IReferenceRepository referenceRepository;
        public ReferenceService(IReferenceRepository referenceRepository)
        {
            this.referenceRepository = referenceRepository;
        }
        public async Task<ReferenceDTO> CreateRefAsync(CreateReferenceDTO dto)
        {
            Reference existedReference = referenceRepository.FindRefByName(dto.name);
            if (existedReference != null)
            {
                throw new DuplicateEntityException("Duplicated name of reference");
            }
            Reference createdRef = Mapper.GetMapper().Map<Reference>(dto);
            createdRef.id = Guid.NewGuid();
            createdRef.status = true;
            Reference insertedRef = await referenceRepository.AddAsync(createdRef);
            return Mapper.GetMapper().Map<ReferenceDTO>(insertedRef);
        }

        public async Task<ReferenceDTO> DeleteRefByIdAsync(Guid id)
        {
            Reference existedRef = await referenceRepository.FindByIdAsync(id);
            if (existedRef != null && existedRef.status)
            {
                existedRef.status = false;
                Reference deletedRef= await referenceRepository.UpdateAsync(existedRef);
                return Mapper.GetMapper().Map<ReferenceDTO>(deletedRef);
            }
            throw new NotFoundEntityException("Not found reference with id");
        }

        public async Task<ReferenceDTO> FindRefByIdAsync(Guid id)
        {
            Reference reference = await referenceRepository.FindByIdAsync(id);
            if (reference != null && reference.status)
            {
                return Mapper.GetMapper().Map<ReferenceDTO>(reference);
            }

            throw new NotFoundEntityException("Not found reference with id");
        }

        public async Task<ReferenceDTO> UpdateRefAsync(UpdateReferenceDTO dto)
        {
            Reference existedRefId = await referenceRepository.FindByIdAsync(dto.id);
            if (existedRefId != null && existedRefId.status)
            {
                Reference existedRefName = referenceRepository.FindRefByNameAndNotId(dto.id, dto.name);
                if (existedRefName == null)
                {
                    existedRefId.name = dto.name;
                    existedRefId.description = dto.description;
                    existedRefId.url = dto.url;
                    existedRefId.categoryName = dto.categoryName;
                    Reference updatedRef = await referenceRepository.UpdateAsync(existedRefId);
                    return Mapper.GetMapper().Map<ReferenceDTO>(updatedRef);
                }
                throw new DuplicateEntityException("Duplicated name of reference");
            }
            throw new NotFoundEntityException("Not found reference with id");
        }
    }
}
