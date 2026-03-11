using Base.Data;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Business.Interfaces.Repositories;
using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly Context _context;

        public IngredientRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(Ingredient dto)
        {
            await _context.Ingredients.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await GetByIdAsync(id);
            _context.Ingredients.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients.AsNoTracking().Include(ri => ri.RecipeIngredients).Include(i => i.InventoryItems).ToListAsync();
        }

        public async Task<Ingredient> GetByIdAsync(Guid id)
        {
            var result = await _context.Ingredients.Include(ri=> ri.RecipeIngredients).Include(i => i.InventoryItems).FirstOrDefaultAsync(r => r.Id == id);
            return result == null ? throw new KeyNotFoundException($"Ingredient with ID {id} not found.") : result;
        }

        public async Task UpdateAsync(Ingredient dto)
        {
            var existingIngredient = await GetByIdAsync(dto.Id);
            _context.Entry(existingIngredient).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();
        }
    }
}
