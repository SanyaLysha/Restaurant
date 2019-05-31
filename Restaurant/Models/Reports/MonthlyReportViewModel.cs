using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models.Reports
{
    public class MonthlyReportViewModel
    {
        public List<ProductModel> barOrders { get; set; }
        public List<ProductModel> kitchenOrders { get; set; }
        public List<Waiter> Waiters { get; set; }
    }
}