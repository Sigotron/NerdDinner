using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner.Models;

namespace NerdDinner.Controllers
{
    public class DinnersController : Controller
    {
        // Fields
        DinnerRepository _dinnerRepo = new DinnerRepository();

        //
        // GET: /Dinner/

        public ActionResult Index()
        {
            var dinners = _dinnerRepo.FindUpcomingDinners().ToList();
            return View(dinners);
        }

        //
        // GET: /Dinners/Details/2

        public ActionResult Details(int id)
        {
            var dinner = _dinnerRepo.GetDinner(id);
            return dinner == null ? View("NotFound") : View(dinner);
        }

        //
        // GET: /Dinners/Edit/2

        public ActionResult Edit(int id)
        {
            Dinner dinner = _dinnerRepo.GetDinner(id);
            return View(dinner);
        }

        //
        // POST: /Dinners/Edit/2

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Dinner dinner = _dinnerRepo.GetDinner(id);
            try
            {
                UpdateModel(dinner);
                _dinnerRepo.Save();
                return RedirectToAction("Details", new { id = dinner.DinnerId });
            }
            catch
            {
                foreach (var issue in dinner.GetRuleViolations())
                {
                    ModelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
                }
                return View(dinner);
            }
        }
    }
}
