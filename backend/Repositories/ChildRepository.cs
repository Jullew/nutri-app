using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutriApp.Data;
using NutriApp.Models.Children;

namespace NutriApp.Repositories
{
    public class ChildRepository : IChildRepository
    {
        private readonly AppDbContext _context;

        public ChildRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Child>> GetAllChildrenAsync()
        {
            return await _context.Children.ToListAsync();
        }

        public async Task<Child?> GetChildByIdAsync(Guid id)
        {
            return await _context.Children.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Child>> GetChildrenByUserIdAsync(Guid userId)
        {
            return await _context.Children.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<Child> CreateChildAsync(Child child)
        {
            _context.Children.Add(child);
            await _context.SaveChangesAsync();
            return child;
        }

        public async Task UpdateChildAsync(Child child)
        {
            _context.Children.Update(child);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChildAsync(Guid id)
        {
            var child = await GetChildByIdAsync(id);
            if (child != null)
            {
                _context.Children.Remove(child);
                await _context.SaveChangesAsync();
            }
        }
    }
}
