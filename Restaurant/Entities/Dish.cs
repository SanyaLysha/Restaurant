using System.Collections.Generic;

namespace Restaurant.Entities
{
    public class Dish
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }

        public virtual ICollection<KitchenOrder> KitchenOrders { get; set; }
        public virtual ICollection<DishRecipe> DishRecipes { get; set; }
    }
}