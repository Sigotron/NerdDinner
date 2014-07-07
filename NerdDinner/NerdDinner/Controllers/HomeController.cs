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

        //
        // GET: /Dinner/

        public ActionResult Index(int? page)
        {
            const int pageSize = 1;
            var dinners = _dinnerRepo.FindUpcomingDinners();
            var paginatedDinners = new PaginatedList<Dinner>(dinners, page ?? 0, pageSize);
            return View(paginatedDinners);
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
