using Pasteleria.Shared.DTOs;
using Base.Shared.Extensions;

namespace Pasteleria.Business.Interfaces.Services
{
    public interface IInventoryItemService
    {
        Task<Result<List<ListInventoryItemDto>>> GetAllInventoryItemsAsync();
        Task<Result<InventoryItemDto>> GetInventoryItemByIdAsync(Guid id);
        Task<Result<InventoryItemDto>> AddInventoryItemAsync(CreateInventoryItemDto inventoryItemDto);
        Task<Result<InventoryItemDto>> UpdateInventoryItemAsync(InventoryItemDto inventoryItemDto);
        Task<Result<bool>> DeleteInventoryItemAsync(Guid id);
    }
}