using AutoMapper;
using Base.Shared.Auth.Dtos;
using Base.Shared.Models;
using Pasteleria.Shared.DTOs;
using Pasteleria.Shared.Models;

namespace Base.Business.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // Users
            CreateMap<UserRegistrationRequestDto, User>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            // Documents
            CreateMap<DocumentDto, Document>().ReverseMap();
            CreateMap<CreateDocumentDto, Document>().ReverseMap();
            CreateMap<ListDocumentDto, Document>().ReverseMap();

            // Ingredients
            CreateMap<IngredientDto, Ingredient>().ReverseMap();
            CreateMap<CreateIngredientDto, Ingredient>().ReverseMap();
            CreateMap<ListIngredientDto, Ingredient>().ReverseMap();
            CreateMap<UpdateIngredientDto, Ingredient>().ReverseMap();

            // Inventory
            CreateMap<InventoryItemDto, InventoryItem>().ReverseMap();
            CreateMap<CreateInventoryItemDto, InventoryItem>().ReverseMap();
            CreateMap<ListInventoryItemDto, InventoryItem>().ReverseMap();

            // Recipe
            CreateMap<RecipeDto, Recipe>().ReverseMap();
            CreateMap<CreateRecipeDto, Recipe>().ReverseMap();
            CreateMap<ListRecipeDto, Recipe>().ReverseMap();

            // RecipeInventory
            CreateMap<RecipeIngredientDto, RecipeIngredient>().ReverseMap();
            CreateMap<CreateRecipeIngredientDto, RecipeIngredient>().ReverseMap();
            CreateMap<ListRecipeIngredientDto, RecipeIngredient>().ReverseMap();
        }
    }
}
