﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class DinnerRepository
    {
        // Query Methods
        public IQueryable<Dinner> FindAllDinners();
        public IQueryable<Dinner> FindUpcomingDinners();
        public Dinner GetDinner(int id);

        // Insert/Delete
        public void Add(Dinner dinner);
        public void Delete(Dinner dinner);

        // Persistence
        public void Save();
    }
}