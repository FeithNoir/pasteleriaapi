using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Interfaces.Repositories
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetAllAsync();
        Task<Recipe?> GetByIdAsync(Guid id);
        Task AddAsync(Recipe entity);
        Task UpdateAsync(Recipe entity);
        Task DeleteAsync(Guid id);
    }
}