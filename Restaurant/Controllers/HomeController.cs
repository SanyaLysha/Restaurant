using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //AppDbContext context = new AppDbContext();
            //context.Database.CreateIfNotExists();
            //context.Roles.Add(new Entities.Role()
            //{
            //    Id = 1,
            //    Name = "Admin"
            //});
            //context.Roles.Add(new Entities.Role()
            //{
            //    Id = 2,
            //    Name = "User"
            //});
            //context.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Tables()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}