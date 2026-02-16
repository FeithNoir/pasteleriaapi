using Base.Business.Interfaces.Repositories;
using Base.Business.MappingProfiles;
using Base.Business.Services;
using Base.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Pasteleria.Business.Interfaces.Repositories;
using Pasteleria.Business.Interfaces.Services;
using Pasteleria.Business.Repositories;
using Pasteleria.Business.Services;

public static class DependencyInjection
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // Configuración de AutoMapper
        services.AddAutoMapper(typeof(MappingConfig));

        // Configuración de repositorios
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
        services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
        services.AddScoped<IRecipeRepository, RecipeRepository >();

        // Configuración de servicios
<<<<<<< HEAD
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddScoped<IInventoryItemService, InventoryItemService>();
        services.AddScoped<IRecipeService, RecipeService>();
        services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
=======
        services.AddScoped<AuthService>();
        services.AddScoped<IIngredientService, IngredientService>();
>>>>>>> a35fed2aeafc6041218fa22d78ef697c789d5bd7
    }
}
