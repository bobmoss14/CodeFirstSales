using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesEf;
using SalesEf.Migrations;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Sales Context = new Sales();
        public ActionResult Index()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<Sales, Configuration>());
            var result = Context.Customers.ToList();
            ViewBag.Title = "Home Page";
            ViewBag.Customers = result;
            return View();
        }
    }
}
