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
        public DateTime dtFrom { get; set; }
        public DateTime dtTo { get; set; }
        public int OrdersCount { get; set; }

        public MonthlyReportViewModel(DateTime from, DateTime to)
        {
            dtFrom = from;
            dtTo = to;
        }
        public class Visit
        {
            public string Date { get; set; }
            public int VisitorsNumber { get; set; }
        }
    }
}