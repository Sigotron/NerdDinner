﻿using System;
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
        readonly DinnerRepository _dinnerRepo = new DinnerRepository();

        //
        // GET: /Dinner/

        public ActionResult Index()
        {
            IEnumerable<Dinner> dinners = _dinnerRepo.FindUpcomingDinners().ToList();
            return View(dinners);
        }

        //
        // GET: /Dinners/Details/2

        public ActionResult Details(int id)
        {
            var dinner = _dinnerRepo.GetDinner(id);
            return dinner == null ? View("NotFound") : View(dinner);
        }

    }
}