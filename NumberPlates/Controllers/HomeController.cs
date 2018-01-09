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
            ViewBag.Plates = db.PlateNumbers
                .OrderByDescending(p => p.Id)
                .Take(20)
                .ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Generate(string lga, int count)
        {
            int start;
            // Get last number in LGA
            var latest = db.PlateNumbers
                            .OrderByDescending(p => p.Number)
                            .Where(p => p.LGA == lga)
                            .FirstOrDefault();

            if (latest == null)
            {
                start = 1;
            }
            else
            {
                start = latest.Number + 1;
            }
            
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    db.PlateNumbers.Add(new PlateNumber { LGA = lga, Number = start, Letter = "AA" });
                    start++;
                }
            }

            db.SaveChanges();

            return RedirectToAction("Index");
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