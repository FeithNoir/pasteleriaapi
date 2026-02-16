using Pasteleria.Shared.Models;

namespace Pasteleria.Shared.DTOs
{
    public class RecipeIngredientDto
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = new Recipe();

        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = new Ingredient();

        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
    }

    public class CreateRecipeIngredientDto
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = new Recipe();

        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = new Ingredient();

        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
    }

    public class ListRecipeIngredientDto
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = new Recipe();

        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = new Ingredient();

        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
