using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Entities
{
    public class ProductStorage
    {
        [Key,ForeignKey("Product")]
        public int ProductId { get; set; }
        public float Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}