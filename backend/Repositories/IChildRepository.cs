using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutriApp.Models.Children;

namespace NutriApp.Repositories
{
    public interface IChildRepository
    {
        Task<IEnumerable<Child>> GetAllChildrenAsync();
        Task<Child?> GetChildByIdAsync(Guid id);
        Task<IEnumerable<Child>> GetChildrenByUserIdAsync(Guid userId);
        Task<Child> CreateChildAsync(Child child);
        Task UpdateChildAsync(Child child);
        Task DeleteChildAsync(Guid id);
    }
}
