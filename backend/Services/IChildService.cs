using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutriApp.DTOs;
using NutriApp.DTOs.Children;

namespace NutriApp.Services
{
    public interface IChildService
    {
        Task<IEnumerable<ChildDTO>> GetAllChildrenAsync();
        Task<ChildDTO?> GetChildByIdAsync(Guid id);
        Task<IEnumerable<ChildDTO>> GetChildrenByUserIdAsync(Guid userId);
        Task<ChildDTO> CreateChildAsync(ChildDTO childDto);
        Task UpdateChildAsync(ChildDTO childDto);
        Task DeleteChildAsync(Guid id);
    }
}
