using Base.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Shared.Models;

namespace Base.Data
{
    public class Context : IdentityDbContext<User, IdentityRole, string>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}