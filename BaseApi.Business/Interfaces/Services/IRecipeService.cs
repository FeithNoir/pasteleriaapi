using Pasteleria.Shared.DTOs;
using Base.Shared.Extensions;

namespace Pasteleria.Business.Interfaces.Services
{
    public interface IRecipeService
    {
        Task<Result<List<ListRecipeDto>>> GetAllRecipesAsync();
        Task<Result<RecipeDto>> GetRecipeByIdAsync(Guid id);
        Task<Result<RecipeDto>> AddRecipeAsync(CreateRecipeDto recipeDto);
        Task<Result<RecipeDto>> UpdateRecipeAsync(RecipeDto recipeDto);
        Task<Result<bool>> DeleteRecipeAsync(Guid id);
    }
}