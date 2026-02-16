using AutoMapper;
using Pasteleria.Business.Interfaces.Repositories;
using Pasteleria.Business.Interfaces.Services;
using Pasteleria.Shared.DTOs;
<<<<<<< HEAD
using Base.Shared.Extensions;
=======
>>>>>>> a35fed2aeafc6041218fa22d78ef697c789d5bd7
using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Services
{
    public class IngredientService : IIngredientService
    {
<<<<<<< HEAD
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<ListIngredientDto>>> GetAllIngredientsAsync()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            var ingredientDtos = _mapper.Map<List<ListIngredientDto>>(ingredients);
            return Result<List<ListIngredientDto>>.Success(ingredientDtos);
        }

        public async Task<Result<IngredientDto>> GetIngredientByIdAsync(Guid id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);
            if (ingredient == null)
            {
                return Result<IngredientDto>.Failure(new List<string> { $"Ingredient with ID {id} not found." });
            }
            var ingredientDto = _mapper.Map<IngredientDto>(ingredient);
            return Result<IngredientDto>.Success(ingredientDto);
        }

        public async Task<Result<IngredientDto>> AddIngredientAsync(CreateIngredientDto ingredientDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDto);
            await _ingredientRepository.AddAsync(ingredient);
            var createdIngredientDto = _mapper.Map<IngredientDto>(ingredient);
            return Result<IngredientDto>.Success(createdIngredientDto);
        }

        public async Task<Result<IngredientDto>> UpdateIngredientAsync(IngredientDto ingredientDto)
        {
            var existingIngredient = await _ingredientRepository.GetByIdAsync(ingredientDto.Id);
            if (existingIngredient == null)
            {
                return Result<IngredientDto>.Failure(new List<string> { $"Ingredient with ID {ingredientDto.Id} not found." });
            }

            _mapper.Map(ingredientDto, existingIngredient);
            await _ingredientRepository.UpdateAsync(existingIngredient);
            return Result<IngredientDto>.Success(ingredientDto);
        }

        public async Task<Result<bool>> DeleteIngredientAsync(Guid id)
        {
            var existingIngredient = await _ingredientRepository.GetByIdAsync(id);
            if (existingIngredient == null)
            {
                return Result<bool>.Failure(new List<string> { $"Ingredient with ID {id} not found." });
            }

            await _ingredientRepository.DeleteAsync(id);
            return Result<bool>.Success(true);
=======
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateIngredientDto dto)
        {
            var ingredient = _mapper.Map<Ingredient>(dto);
            await _repository.AddAsync(ingredient);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ListIngredientDto>> GetAllAsync()
        {
            var ingredients = await _repository.GetAllAsync();
            return _mapper.Map<List<ListIngredientDto>>(ingredients);
        }

        public async Task<IngredientDto> GetByIdAsync(Guid id)
        {
            var ingredient = await _repository.GetByIdAsync(id);
            return _mapper.Map<IngredientDto>(ingredient);
        }

        public async Task UpdateAsync(UpdateIngredientDto dto)
        {
            var ingredient = _mapper.Map<Ingredient>(dto);
            await _repository.UpdateAsync(ingredient);
>>>>>>> a35fed2aeafc6041218fa22d78ef697c789d5bd7
        }
    }
}
