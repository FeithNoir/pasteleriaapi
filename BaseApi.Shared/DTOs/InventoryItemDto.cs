using Pasteleria.Shared.Models;

namespace Pasteleria.Shared.DTOs
{
    public class InventoryItemDto
    {
        public Guid Id { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = new Ingredient();
        public decimal CurrentQuantity { get; set; }
        public decimal MinimumQuantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Location { get; set; } = string.Empty;
        public bool IsLowStock() => CurrentQuantity < MinimumQuantity;
    }

    public class CreateInventoryItemDto
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = new Ingredient();
        public decimal CurrentQuantity { get; set; }
        public decimal MinimumQuantity { get; set; }
        public string Location { get; set; } = string.Empty;
    }

    public class ListInventoryItemDto
    {
        public Guid Id { get; set; }
        public int IngredientId { get; set; }
        public decimal CurrentQuantity { get; set; }
        public decimal MinimumQuantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
