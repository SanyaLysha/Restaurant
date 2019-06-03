using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace Restaurant.Models.Reports
{
    public class DailyReportViewModel
    {
        public List<ProductModel> barOrders { get; set; }
        public List<ProductModel> kitchenOrders { get; set; }
        public List<Waiter> Waiters { get; set; }
        public List<ProductModel> TrendDishes = new List<ProductModel>();
        public List<ProductModel> TrendDrinks = new List<ProductModel>();
        public int OrdersCount { get; set; }
        public int BookTablesCount { get; set; }
        public float TotalAmount { get; set; } = 0;
        public DateTime dt { get; set; }
        AppDbContext db = new AppDbContext();

        public DailyReportViewModel(DateTime dateTime)
        {
            dt = dateTime;
            SetSoldGoods();
            SetTotalAmount();
            SetWaiters();
            SetTrend();
            SetBookTablesCount();

        }
        public void SetSoldGoods()
        {
            kitchenOrders = (from ordr in db.KitchenOrders
                             where
                                SqlFunctions.DatePart("day", ordr.Order.Date) == SqlFunctions.DatePart("day", dt) &&
                                SqlFunctions.DatePart("month", ordr.Order.Date) == SqlFunctions.DatePart("month", dt) &&
                                SqlFunctions.DatePart("year", ordr.Order.Date) == SqlFunctions.DatePart("year", dt)
                             group ordr by new
                             {
                                 ordr.Dish.Name,
                                 ordr.Dish.Price
                             } into ord
                             select new ProductModel()
                             {
                                 Name = ord.Key.Name,
                                 Number = ord.Count(),
                                 Cost = ord.Key.Price
                             }).ToList();
            barOrders = (from ordr in db.BarOrders
                         where
                            SqlFunctions.DatePart("day", ordr.Order.Date) == SqlFunctions.DatePart("day", dt) &&
                            SqlFunctions.DatePart("month", ordr.Order.Date) == SqlFunctions.DatePart("month", dt) &&
                            SqlFunctions.DatePart("year", ordr.Order.Date) == SqlFunctions.DatePart("year", dt)
                         group ordr by new
                         {
                             ordr.Drink.Name,
                             ordr.Drink.Price
                         } into ord
                         select new ProductModel()
                         {
                             Name = ord.Key.Name,
                             Number = ord.Count(),
                             Cost = ord.Key.Price
                         }).ToList();
        }
        public void SetWaiters()
        {
            Waiters = new List<Waiter>();
            Waiters.AddRange((from ordr in db.Orders
                              where
                                 SqlFunctions.DatePart("day", ordr.Date) == SqlFunctions.DatePart("day", dt) &&
                                 SqlFunctions.DatePart("month", ordr.Date) == SqlFunctions.DatePart("month", dt) &&
                                 SqlFunctions.DatePart("year", ordr.Date) == SqlFunctions.DatePart("year", dt)
                              group ordr by new
                              {
                                  ordr.Person.FirstName,
                                  ordr.Person.LastName,
                                  ordr.Person.Phone,
                                  ordr.Person.Salary.Size
                              } into ord
                              select new Waiter()
                              {
                                  FirstName = ord.Key.FirstName,
                                  LastName = ord.Key.LastName,
                                  Phone = ord.Key.Phone,
                                  Salary = ord.Key.Size,
                                  OrdersCount = ord.Count()
                              }).ToList());
            Waiters.ForEach(w => OrdersCount += w.OrdersCount);
        }
        public void SetTotalAmount()
        {
            kitchenOrders.ForEach(k => TotalAmount += k.Cost * k.Number);
            barOrders.ForEach(k => TotalAmount += k.Cost * k.Number);
        }
        public void SetTrend()
        {
            var defNumber = kitchenOrders.Count != 0 ? kitchenOrders.Max(o=> o.Number) : 0;
            TrendDishes.AddRange(kitchenOrders.Where(o => o.Number == defNumber));

            defNumber = barOrders.Count != 0 ? barOrders.Max(o => o.Number):0;
            TrendDrinks.AddRange(barOrders.Where(o => o.Number == defNumber));
        }
        public void SetBookTablesCount()
        {
            BookTablesCount = (from ordr in db.TableOrders
                               where
                                  SqlFunctions.DatePart("day", ordr.Date) == SqlFunctions.DatePart("day", dt) &&
                                  SqlFunctions.DatePart("month", ordr.Date) == SqlFunctions.DatePart("month", dt) &&
                                  SqlFunctions.DatePart("year", ordr.Date) == SqlFunctions.DatePart("year", dt)
                               select ordr.Id).Count();
        }
    }
    public class ProductModel
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int Volume { get; set; }
        public float Cost { get; set; }
    }
    public class Waiter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }
        public int OrdersCount { get; set; }
    }

}