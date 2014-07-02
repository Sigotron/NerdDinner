using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner.Controllers
{
    public class DinnerController : Controller
    {
        //
        // GET: /Dinner/

        public string Index()
        {
            return "Coming soon, Dinners!";
        }

        //
        // GET: /Dinners/Details/2

        public string Details(int id)
        {
            return "Details DinnerID: " + id;
        }

    }
}
