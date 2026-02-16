namespace Pasteleria.Shared.Models
{
    public class InventoryItem : BaseEntity
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = new Ingredient();

        public decimal CurrentQuantity { get; set; }
        public decimal MinimumQuantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Location { get; set; } = string.Empty; // Opcional: ubicación en almacén

        // Método para verificar si está bajo stock
        public bool IsLowStock() => CurrentQuantity < MinimumQuantity;
    }
}
