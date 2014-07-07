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

        public ActionResult Index(int? page)
        {
            const int pageSize = 10;
            var dinners = _dinnerRepo.FindUpcomingDinners();
            var paginatedDinners = dinners.Skip((page ?? 0) * pageSize).Take(pageSize).ToList();
            return View(paginatedDinners);
        }

        //
        // GET: /Dinners/Details/2

        public ActionResult Details(int id)
        {
            var dinner = _dinnerRepo.GetDinner(id);
            return dinner == null ? View("NotFound") : View(dinner);
        }

        //
        // GET: /Dinners/Edit/5

        [Authorize]
        public ActionResult Edit(int id)
        {
            Dinner dinner = _dinnerRepo.GetDinner(id);
            return View(new DinnerFormViewModel(dinner));
        }

        //
        // POST: /Dinners/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
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
                ModelState.AddRuleViolations(dinner.GetRuleViolations());
                return View(new DinnerFormViewModel(dinner));
            }
        }

        //
        // GET: /Dinners/Create

        public ActionResult Create()
        {
            Dinner dinner = new Dinner()
            {
                EventDate = DateTime.Now.AddDays(7)
            };
            return View(new DinnerFormViewModel(dinner));
        }

        //
        // POST: /Dinners/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Dinner dinner)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dinner.HostedBy = "SomeUser";
                    _dinnerRepo.Add(dinner);
                    _dinnerRepo.Save();
                    return RedirectToAction("Details", new { id = dinner.DinnerId });
                }
                catch
                {
                    ModelState.AddRuleViolations(dinner.GetRuleViolations());
                }
            }
            return View(new DinnerFormViewModel(dinner));
        }
 
 

        //
        // GET: /Dinners/Delete/2

        public ActionResult Delete(int id)
        {
            Dinner dinner = _dinnerRepo.GetDinner(id);
            if (dinner == null) return View("NotFound");
            else return View(dinner);
        }

        //
        // HTTP POST: /Dinners/Delete/1

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            Dinner dinner = _dinnerRepo.GetDinner(id);
            if (dinner == null)
                return View("NotFound");
            _dinnerRepo.Delete(dinner);
            _dinnerRepo.Save();
            return View("Deleted");
        }
    }
}
