using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Interfaces.Repositories
{
    public interface IInventoryItemRepository
    {
        Task<List<InventoryItem>> GetAllAsync();
        Task<InventoryItem?> GetByIdAsync(Guid id);
        Task AddAsync(InventoryItem entity);
        Task UpdateAsync(InventoryItem entity);
        Task DeleteAsync(Guid id);
    }
}
