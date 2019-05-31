using System;
using System.Collections.Generic;

namespace Restaurant.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long PersonId { get; set; }

        public virtual StaffPerson Person { get; set; }
        public virtual ICollection<BarOrder> BarOrders { get; set; }
        public virtual ICollection<KitchenOrder> KitchenOrders { get; set; }

    }
}