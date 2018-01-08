using NumberPlates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumberPlates.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Lgas = db.LocalGoverments.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Generate(string lga, int count)
        {
            if (count > 0)
            {
                for (int i = 0; i <= count; i++)
                {
                    db.PlateNumbers.Add(new PlateNumber {});
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}