using Base.Data;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Business.Interfaces.Repositories;
using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Repositories
{
    public class InventoryItemRepository : IInventoryItemRepository
    {
        private readonly Context _context;

        public InventoryItemRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(InventoryItem dto)
        {
            await _context.InventoryItems.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await GetByIdAsync(id);
            if (result != null)
            {
                _context.InventoryItems.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<InventoryItem>> GetAllAsync()
        {
            return await _context.InventoryItems.AsNoTracking().ToListAsync();
        }

        public async Task<InventoryItem?> GetByIdAsync(Guid id)
        {
            return await _context.InventoryItems.Include(i => i.Ingredient).AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateAsync(InventoryItem dto)
        {
            _context.InventoryItems.Update(dto);
            await _context.SaveChangesAsync();
        }
    }
}
