using System;
using System.Linq;

namespace NerdDinner.Models
{
    public class DinnerRepository
    {
        // field
        private readonly NerdDinnerEntities _db = new NerdDinnerEntities();

        // Query Methods
        public IQueryable<Dinner> FindAllDinners()
        {
            return _db.Dinners;
        }

        public IQueryable<Dinner> FindUpcomingDinners()
        {
            return from dinner in _db.Dinners
                   where dinner.EventDate > DateTime.Now
                   orderby dinner.EventDate
                   select dinner;
        }

        public Dinner GetDinner(int id)
        {
            return _db.Dinners.SingleOrDefault(d => d.DinnerId == id);
        }

        // Insert/Delete
        public void Add(Dinner dinner)
        {
            _db.Dinners.Add(dinner);
        }


        public void Delete(Dinner dinner)
        {
            if (_db.Dinners.Contains(dinner))
            {
                _db.Dinners.Remove(dinner);
            }
        }

        // Persistence
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}