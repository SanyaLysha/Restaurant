using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Entities
{
    public class TableOrder
    {
        public long Id { get; set; }
        public int TableId { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }

        public virtual Table Table { get; set; }
        public virtual User User { get; set; }
    }
}