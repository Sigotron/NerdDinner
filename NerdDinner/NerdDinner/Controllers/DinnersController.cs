using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner.DataStructures;
using NerdDinner.Models;

namespace NerdDinner.Controllers
{
    public class DinnersController : Controller
    {
        // Fields
        IDinnerRepository _dinnerRepo;

        public DinnersController()
            : this(new DinnerRepository())
        {
        }

        public DinnersController(IDinnerRepository repository)
        {
            _dinnerRepo = repository;
        }

        //
        // GET: /Dinner/

        public ActionResult Index(int? page)
        {
            const int pageSize = 5;
            var dinners = _dinnerRepo.FindUpcomingDinners();
            var paginatedDinners = new PaginatedList<Dinner>(dinners, page ?? 0, pageSize);
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

            if (!dinner.IsHostedBy(User.Identity.Name))
                return View("InvalidOwner");

            return View(new DinnerFormViewModel(dinner));
        }

        //
        // POST: /Dinners/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Dinner dinner = _dinnerRepo.GetDinner(id);

            if (!dinner.IsHostedBy(User.Identity.Name))
                return View("InvalidOwner");

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

        [Authorize]
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

        [AcceptVerbs(HttpVerbs.Post), Authorize]
        public ActionResult Create(Dinner dinner)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    dinner.HostedBy = User.Identity.Name;

                    RSVP rsvp = new RSVP();
                    rsvp.AttendeeName = User.Identity.Name;
                    dinner.RSVPs = new Collection<RSVP>();
                    dinner.RSVPs.Add(rsvp);

                    _dinnerRepo.Add(dinner);
                    _dinnerRepo.Save();
                 
                    return RedirectToAction("Details", new { id = dinner.DinnerId });
                }
                catch(DbUpdateException)
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
