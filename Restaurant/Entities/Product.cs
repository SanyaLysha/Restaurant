using System.Collections.Generic;

namespace Restaurant.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DishRecipe> DishRecipes { get; set; }
        public virtual ICollection<DrinkRecipe> DrinkRecipes { get; set; }
        public virtual ProductStorage ProductStorage { get; set; }

    }
}