using AutoMapper;
using Pasteleria.Business.Interfaces.Repositories;
using Pasteleria.Business.Interfaces.Services;
using Pasteleria.Shared.DTOs;
using Base.Shared.Extensions;
using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Services
{
    public class InventoryItemService : IInventoryItemService
    {
        private readonly IInventoryItemRepository _inventoryItemRepository;
        private readonly IMapper _mapper;

        public InventoryItemService(IInventoryItemRepository inventoryItemRepository, IMapper mapper)
        {
            _inventoryItemRepository = inventoryItemRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<ListInventoryItemDto>>> GetAllInventoryItemsAsync()
        {
            var inventoryItems = await _inventoryItemRepository.GetAllAsync();
            var inventoryItemDtos = _mapper.Map<List<ListInventoryItemDto>>(inventoryItems);
            return Result<List<ListInventoryItemDto>>.Success(inventoryItemDtos);
        }

        public async Task<Result<InventoryItemDto>> GetInventoryItemByIdAsync(Guid id)
        {
            var inventoryItem = await _inventoryItemRepository.GetByIdAsync(id);
            if (inventoryItem == null)
            {
                return Result<InventoryItemDto>.Failure(new List<string> { $"InventoryItem with ID {id} not found." });
            }
            var inventoryItemDto = _mapper.Map<InventoryItemDto>(inventoryItem);
            return Result<InventoryItemDto>.Success(inventoryItemDto);
        }

        public async Task<Result<InventoryItemDto>> AddInventoryItemAsync(CreateInventoryItemDto inventoryItemDto)
        {
            var inventoryItem = _mapper.Map<InventoryItem>(inventoryItemDto);
            await _inventoryItemRepository.AddAsync(inventoryItem);
            var createdInventoryItemDto = _mapper.Map<InventoryItemDto>(inventoryItem);
            return Result<InventoryItemDto>.Success(createdInventoryItemDto);
        }

        public async Task<Result<InventoryItemDto>> UpdateInventoryItemAsync(InventoryItemDto inventoryItemDto)
        {
            var existingInventoryItem = await _inventoryItemRepository.GetByIdAsync(inventoryItemDto.Id);
            if (existingInventoryItem == null)
            {
                return Result<InventoryItemDto>.Failure(new List<string> { $"InventoryItem with ID {inventoryItemDto.Id} not found." });
            }

            _mapper.Map(inventoryItemDto, existingInventoryItem);
            await _inventoryItemRepository.UpdateAsync(existingInventoryItem);
            return Result<InventoryItemDto>.Success(inventoryItemDto);
        }

        public async Task<Result<bool>> DeleteInventoryItemAsync(Guid id)
        {
            var existingInventoryItem = await _inventoryItemRepository.GetByIdAsync(id);
            if (existingInventoryItem == null)
            {
                return Result<bool>.Failure(new List<string> { $"InventoryItem with ID {id} not found." });
            }

            await _inventoryItemRepository.DeleteAsync(id);
            return Result<bool>.Success(true);
        }
    }
}
