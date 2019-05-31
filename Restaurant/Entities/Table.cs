using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int TableStatusId { get; set; }

        public TableStatus TableStatus { get; set; }
    }
}