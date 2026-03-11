using AutoMapper;
using Pasteleria.Business.Interfaces.Repositories;
using Pasteleria.Business.Interfaces.Services;
using Pasteleria.Shared.DTOs;
using Base.Shared.Extensions;
using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<ListRecipeDto>>> GetAllRecipesAsync()
        {
            var recipes = await _recipeRepository.GetAllAsync();
            var recipeDtos = _mapper.Map<List<ListRecipeDto>>(recipes);
            return Result<List<ListRecipeDto>>.Success(recipeDtos);
        }

        public async Task<Result<RecipeDto>> GetRecipeByIdAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                return Result<RecipeDto>.Failure(new List<string> { $"Recipe with ID {id} not found." });
            }
            var recipeDto = _mapper.Map<RecipeDto>(recipe);
            return Result<RecipeDto>.Success(recipeDto);
        }

        public async Task<Result<RecipeDto>> AddRecipeAsync(CreateRecipeDto recipeDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);
            recipe.Id = Guid.NewGuid();
            
            foreach (var ri in recipe.RecipeIngredients)
            {
                ri.Id = Guid.NewGuid();
                ri.RecipeId = recipe.Id;
            }

            await _recipeRepository.AddAsync(recipe);
            var createdRecipeDto = _mapper.Map<RecipeDto>(recipe);
            return Result<RecipeDto>.Success(createdRecipeDto);
        }

        public async Task<Result<RecipeDto>> UpdateRecipeAsync(RecipeDto recipeDto)
        {
            var existingRecipe = await _recipeRepository.GetByIdAsync(recipeDto.Id);
            if (existingRecipe == null)
            {
                return Result<RecipeDto>.Failure(new List<string> { $"Recipe with ID {recipeDto.Id} not found." });
            }

            _mapper.Map(recipeDto, existingRecipe);
            await _recipeRepository.UpdateAsync(existingRecipe);
            return Result<RecipeDto>.Success(recipeDto);
        }

        public async Task<Result<bool>> DeleteRecipeAsync(Guid id)
        {
            var existingRecipe = await _recipeRepository.GetByIdAsync(id);
            if (existingRecipe == null)
            {
                return Result<bool>.Failure(new List<string> { $"Recipe with ID {id} not found." });
            }

            await _recipeRepository.DeleteAsync(id);
            return Result<bool>.Success(true);
        }
    }
}
