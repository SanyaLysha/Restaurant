using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    public class BarOrder
    {
        public long Id { get; set; }
        [ForeignKey("Order")]
        public long OrderId { get; set; }
        [ForeignKey("Drink")]
        public long DrinkId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Drink Drink { get; set; }
    }
}