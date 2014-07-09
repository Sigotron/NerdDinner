using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner.DataStructures;
using NerdDinner.Models;

namespace NerdDinner.Controllers
{
    public class HomeController : Controller
    {

        // Fields
        DinnerRepository _dinnerRepo = new DinnerRepository();

        public ActionResult Index()
        {
            var dinners = _dinnerRepo.FindUpcomingDinners();
            return View(dinners);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
