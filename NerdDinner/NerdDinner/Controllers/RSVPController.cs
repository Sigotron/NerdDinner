using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner.Models;

namespace NerdDinner.Controllers
{
    public class RSVPController : Controller
    {
        DinnerRepository _dinnerRepo = new DinnerRepository();

        //
        // AJAX: /Dinners/RSVPForEvent/1

        [Authorize, AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(int id, string user)
        {
            Dinner dinner = _dinnerRepo.GetDinner(id);

            if (!dinner.IsUserRegistered(user))
            {
                RSVP rsvp = new RSVP();
                rsvp.AttendeeName = user;

                dinner.RSVPs.Add(rsvp);
                _dinnerRepo.Save();
            }
            return Content("Thanks - we'll see you there!");
        }

    }
}
