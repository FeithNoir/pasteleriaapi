using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Interfaces.Repositories
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient> GetByIdAsync(Guid id);
        Task AddAsync(Ingredient entity);
        Task UpdateAsync(Ingredient entity);
        Task DeleteAsync(Guid id);
    }
}