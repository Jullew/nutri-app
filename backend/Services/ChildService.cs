using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutriApp.DTOs;
using NutriApp.DTOs.Children;
using NutriApp.Models.Children;
using NutriApp.Repositories;

namespace NutriApp.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;

        public ChildService(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<IEnumerable<ChildDTO>> GetAllChildrenAsync()
        {
            var children = await _childRepository.GetAllChildrenAsync();
            return children.Select(c => c.ToDTO());
        }

        public async Task<ChildDTO?> GetChildByIdAsync(Guid id)
        {
            var child = await _childRepository.GetChildByIdAsync(id);
            return child?.ToDTO();
        }

        public async Task<IEnumerable<ChildDTO>> GetChildrenByUserIdAsync(Guid userId)
        {
            var children = await _childRepository.GetChildrenByUserIdAsync(userId);
            return children.Select(c => c.ToDTO());
        }

        public async Task<ChildDTO> CreateChildAsync(ChildDTO childDto)
        {
            var child = new Child
            {
                Id = Guid.NewGuid(),
                Name = childDto.Name,
                BirthDate = childDto.BirthDate,
                UserId = childDto.UserId
            };

            var createdChild = await _childRepository.CreateChildAsync(child);
            return createdChild.ToDTO();
        }

        public async Task UpdateChildAsync(ChildDTO childDto)
        {
            var child = await _childRepository.GetChildByIdAsync(childDto.Id);
            if (child == null) return;

            child.Name = childDto.Name;
            child.BirthDate = childDto.BirthDate;

            await _childRepository.UpdateChildAsync(child);
        }

        public async Task DeleteChildAsync(Guid id)
        {
            await _childRepository.DeleteChildAsync(id);
        }
    }
}
