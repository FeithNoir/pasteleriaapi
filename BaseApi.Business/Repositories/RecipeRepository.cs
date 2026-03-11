using Base.Data;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Business.Interfaces.Repositories;
using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly Context _context;

        public RecipeRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(Recipe dto)
        {
            await _context.Recipes.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var recipe = await GetByIdAsync(id);
            _context.RecipeIngredients.RemoveRange(recipe.RecipeIngredients);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await _context.Recipes.AsNoTracking().Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient).ToListAsync();
        }

        public async Task<Recipe> GetByIdAsync(Guid id)
        {
            var result = await _context.Recipes.AsNoTracking().Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient).FirstOrDefaultAsync(r => r.Id == id);
            return result == null ? throw new KeyNotFoundException($"Recipe with ID {id} not found.") : result;
        }

        public async Task UpdateAsync(Recipe dto)
        {
            var existingRecipe = await GetByIdAsync(dto.Id);
            _context.Entry(existingRecipe).CurrentValues.SetValues(dto);

            foreach (var existingIngredient in existingRecipe.RecipeIngredients.ToList())
            {
                if (!dto.RecipeIngredients.Any(ri => ri.IngredientId == existingIngredient.IngredientId))
                {
                    _context.RecipeIngredients.Remove(existingIngredient);
                }
            }

            foreach (var ingredientDto in dto.RecipeIngredients)
            {
                var existingIngredient = existingRecipe.RecipeIngredients
                    .FirstOrDefault(ri => ri.IngredientId == ingredientDto.IngredientId);

                if (existingIngredient != null)
                {
                    _context.Entry(existingIngredient).CurrentValues.SetValues(ingredientDto);
                }
                else
                {
                    existingRecipe.RecipeIngredients.Add(new RecipeIngredient
                    {
                        IngredientId = ingredientDto.IngredientId,
                        Quantity = ingredientDto.Quantity,
                        Unit = ingredientDto.Unit
                    });
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<decimal> CalculateTotalCostAsync(Guid recipeId)
        {
            var recipe = await GetByIdAsync(recipeId);
            return recipe.RecipeIngredients.Sum(ri => ri.Quantity * ri.Ingredient.CostPerUnit);
        }
    }
}
