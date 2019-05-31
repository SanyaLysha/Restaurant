using Restaurant.Entities;
using System.Data.Entity;

namespace Restaurant.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<BarOrder> BarOrders { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<KitchenOrder> KitchenOrders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<StaffPerson> StaffPeople { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableStatus> TableStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TableOrder> TableOrders { get; set; }
        public DbSet<StaffRole> StaffRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DishRecipe> DishRecipes { get; set; }
        public DbSet<DrinkRecipe> DrinkRecipes { get; set; }
        public DbSet<ProductStorage> ProductStorage { get; set; }

    }
}