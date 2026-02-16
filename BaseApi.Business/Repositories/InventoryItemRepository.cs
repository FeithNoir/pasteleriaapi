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
            var result = GetByIdAsync(id);
            _context.InventoryItems.Remove(result.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<InventoryItem>> GetAllAsync()
        {
            return await _context.InventoryItems.AsNoTracking().ToListAsync();
        }

        public async Task<InventoryItem> GetByIdAsync(Guid id)
        {
            var result = await _context.InventoryItems.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            return result == null ? throw new KeyNotFoundException($"Recipe with ID {id} not found.") : result;
        }

        public async Task UpdateAsync(InventoryItem dto)
        {
            var existingRecipe = GetByIdAsync(dto.Id);
            _context.Entry(existingRecipe).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();
        }
    }
}
