using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Entities
{
    public class TableStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
    }
}