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
            if (result != null)
            {
                _context.Ingredients.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients.AsNoTracking().Include(ri => ri.RecipeIngredients).Include(i => i.InventoryItems).ToListAsync();
        }

        public async Task<Ingredient?> GetByIdAsync(Guid id)
        {
            return await _context.Ingredients.Include(ri=> ri.RecipeIngredients).Include(i => i.InventoryItems).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateAsync(Ingredient dto)
        {
            _context.Ingredients.Update(dto);
            await _context.SaveChangesAsync();
        }
    }
}
