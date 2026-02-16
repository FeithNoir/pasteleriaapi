using Base.Data;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Business.Interfaces.Repositories;
using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Repositories
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly Context _context;

        public RecipeIngredientRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(RecipeIngredient dto)
        {
            await _context.RecipeIngredients.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = GetByIdAsync(id);
            _context.RecipeIngredients.Remove(result.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RecipeIngredient>> GetAllAsync()
        {
            return await _context.RecipeIngredients.AsNoTracking().ToListAsync();
        }

        public async Task<RecipeIngredient> GetByIdAsync(Guid id)
        {
            var result = await _context.RecipeIngredients.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            return result == null ? throw new KeyNotFoundException($"Recipe with ID {id} not found.") : result;
        }

        public async Task UpdateAsync(RecipeIngredient dto)
        {
            var existingRecipe = GetByIdAsync(dto.Id);
            _context.Entry(existingRecipe).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();
        }
    }
}
