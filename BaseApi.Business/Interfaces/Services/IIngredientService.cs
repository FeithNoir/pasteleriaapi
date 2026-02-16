using Pasteleria.Shared.DTOs;
using Base.Shared.Extensions;

namespace Pasteleria.Business.Interfaces.Services
{
    public interface IIngredientService
    {
<<<<<<< HEAD
        Task<Result<List<ListIngredientDto>>> GetAllIngredientsAsync();
        Task<Result<IngredientDto>> GetIngredientByIdAsync(Guid id);
        Task<Result<IngredientDto>> AddIngredientAsync(CreateIngredientDto ingredientDto);
        Task<Result<IngredientDto>> UpdateIngredientAsync(IngredientDto ingredientDto);
        Task<Result<bool>> DeleteIngredientAsync(Guid id);
=======
        Task<IngredientDto> GetByIdAsync(Guid id);
        Task<List<ListIngredientDto>> GetAllAsync();
        Task AddAsync(CreateIngredientDto dto);
        Task UpdateAsync(UpdateIngredientDto dto);
        Task DeleteAsync(Guid id);
>>>>>>> a35fed2aeafc6041218fa22d78ef697c789d5bd7
    }
}