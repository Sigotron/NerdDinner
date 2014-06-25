using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner.Controllers
{
    public class HomeController : Controller
    {
        // ToDo: Is this a field?
        NerdDinners nerdDinners = new NerdDinners();

        public ActionResult Index()
        {
            var dinners = from d in nerdDinners.Dinners
                          where d.EventDate > DateTime.Now
                          select d;

            return View(dinners.ToList());
        }

        public ActionResult Create()
        {
            // ToDo: Find out what this is 
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dinner dinner) 
        {
            if (ModelState.IsValid)
            {
                nerdDinners.Dinners.Add(dinner);
                nerdDinners.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(dinner);
        }
    }
}
