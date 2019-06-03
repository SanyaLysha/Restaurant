using Restaurant.Entities;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class DataController : Controller
    {
        private AppDbContext db = new AppDbContext();
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
        [HttpGet]
        public ActionResult GetTodaySoldDrinks()
        {
            var staff = (from drink in db.Drinks
                         join ordr in db.BarOrders on drink.Id equals ordr.DrinkId into
                         lft from x in lft.DefaultIfEmpty()
                         group drink by new
                         {
                             drink.Name,
                             drink.Price
                         } into ord
                         select new
                         {
                             ord.Key.Name,
                             Number = ord.Key.Id != null ? ord.Count(),
                             Cost = ord.Key.Price
                         });
            return Json(staff, JsonRequestBehavior.AllowGet);
        }
    }
}