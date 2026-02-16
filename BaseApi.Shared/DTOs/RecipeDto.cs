using Pasteleria.Shared.Models;

namespace Pasteleria.Shared.DTOs
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public decimal TotalCost { get; private set; }
        public decimal SuggestedPrice { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }

    public class CreateRecipeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public decimal SuggestedPrice { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }

    public class ListRecipeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TotalCost { get; private set; }
        public decimal SuggestedPrice { get; set; }
    }
}
