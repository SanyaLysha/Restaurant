using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    public class DishRecipe
    {
        public int Id { get; set; }
        public long DishId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public float Quantity { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Product Product { get; set; }
    }
}