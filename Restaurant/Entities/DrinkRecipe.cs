using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    public class DrinkRecipe
    {
        public int Id { get; set; }
        public long DrinkId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public float Quantity { get; set; }

        public virtual Drink Drink { get; set; }
        public virtual Product Product { get; set; }
    }
}