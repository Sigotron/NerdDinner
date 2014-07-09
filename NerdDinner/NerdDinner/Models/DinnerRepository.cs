using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
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
            _db.Dinners.Remove(dinner);
        }

        // Persistence
        public void Save()
        {
            _db.SaveChanges();
        }

        [DbFunction("NerdDinnerModel.Store", "DistanceBetween")]
        public static double DistanceBetween(double lat1, double long1, double lat2, double long2)
        {
            throw new NotImplementedException("Only call through LINQ expression");
        }

        public IQueryable<Dinner> FindByLocation(double latitude, double longitude)
        {
            return from d in _db.Dinners
                   where DistanceBetween(latitude, longitude, d.Latitude, d.Longitude) < 100
                   select d;
        }

    }
}