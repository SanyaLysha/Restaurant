using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    public class KitchenOrder
    {
        public long Id { get; set; }
        [ForeignKey("Order")]
        public long OrderId { get; set; }

        [ForeignKey("Dish")]
        public long DishId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Dish Dish { get; set; }
    }
}