using Restaurant.Entities;
using Restaurant.Models;
using Restaurant.Models.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using static Restaurant.Models.Reports.MonthlyReportViewModel;

namespace Restaurant.Controllers
{
    public class DataController : Controller
    {
        private AppDbContext db = new AppDbContext();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private List<Dish> dishItems;

        [HttpGet]
        public ActionResult GetDishes()
        {
            dishItems = new List<Dish>();
            foreach (var d in db.Dishes)
            {
                dishItems.Add(d);
            }
            return Json(dishItems, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddDish(Dish item, int stuffId)
        {
            try
            {
                db.Dishes.Add(item);
                db.SaveChanges();
                return Json("success: true", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("success: false", JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult GetFreeTables()
        {
            var tables = (from tbl in db.Tables
                          where tbl.TableStatus.Id == (int)Entities.Enum.TableStatus.Free
                          select new
                          {
                              tbl.Id,
                              Status = tbl.TableStatus.Name
                          });
            return Json(tables, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = (from usr in db.Users
                         select new
                         {
                             usr.FirstName,
                             usr.LastName,
                             usr.Email,
                             usr.Phone,
                             Role = usr.role.Name
                         });
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetStaff()
        {
            var staff = (from person in db.StaffPeople
                         select new
                         {
                             person.FirstName,
                             person.LastName,
                             person.Phone,
                             Role = person.Role.Name,
                             Salary = person.Salary.Size
                         });
            return Json(staff, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetTodaySoldDishes()
        {
            var staff = (from ordr in db.KitchenOrders
                         group ordr by new
                         {
                             ordr.Dish.Name,
                             ordr.Dish.Price
                         } into ord
                         select new
                         {
                             ord.Key.Name,
                             Number = ord.Count(),
                             Cost = ord.Key.Price
                         });
            return Json(staff, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetTodaySoldDrinks(string dt)
        {
            var sqltxt = "SELECT d.Name, CASE WHEN bo.DrinkId IS NULL THEN 0 ELSE COUNT(*) END AS Number " +
                " FROM Drinks d LEFT JOIN BarOrders bo ON bo.DrinkId = d.Id " +
                " LEFT JOIN Orders o on o.Id=bo.OrderId " +
                " WHERE CONVERT(date, o.Date) LIKE CONVERT(date, @dt)" +
                " GROUP BY d.Name, bo.DrinkId";
            SqlCommand cmd = new SqlCommand(sqltxt, conn);
            cmd.Parameters.Add(new SqlParameter("@dt", dt));
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            conn.Open();
            adapter.Fill(dataTable);
            conn.Close();
            List<ProductModel> products = new List<ProductModel>();
            foreach (DataRow r in dataTable.Rows)
            {
                products.Add(new ProductModel()
                {
                    Name = r["Name"].ToString(),
                    Number = (int)r["Number"]
                });
            }
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetClientsByDate(string dtFrom, string dtTo)
        {
            var sqltxt = "select Convert(date,o.Date) as Date, Count(*) as Number" +
                " from Orders o " +
                " where Convert(date, o.Date) between Convert(date, @dtFrom) and Convert(date, @dtTo) " +
                " group by Convert(date, o.Date)";
            SqlCommand cmd = new SqlCommand(sqltxt, conn);
            cmd.Parameters.Add(new SqlParameter("@dtFrom", dtFrom));
            cmd.Parameters.Add(new SqlParameter("@dtTo", dtTo));
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            conn.Open();
            adapter.Fill(dataTable);
            conn.Close();
            List<Visit> visits = new List<Visit>();
            foreach (DataRow r in dataTable.Rows)
            {
                visits.Add(new Visit()
                {
                    Date = Convert.ToDateTime(r["Date"]).ToShortDateString(),
                    VisitorsNumber = (int)r["Number"]
                });
            }
            return Json(visits, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetOpenOrders()
        {
            var query = (from ordr in db.Orders
                         join bo in db.BarOrders on ordr.Id equals bo.OrderId
                         join ko in db.KitchenOrders on ordr.Id equals ko.OrderId
                         where ordr.Paid == false
                         select new OrderViewModel()
                         {
                             OrderId = ordr.Id,
                             PersonId = ordr.PersonId,
                             PersonFullName = String.Format("{0} {1}", ordr.Person.FirstName, ordr.Person.LastName),
                             Paid = ordr.Paid,
                             TableId = ordr.TableId

                         }
                         );
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
}