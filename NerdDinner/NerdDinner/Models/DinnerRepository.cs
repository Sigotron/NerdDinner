using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;

namespace NerdDinner.Models
{
    public interface IDinnerRepository
    {
        IQueryable<Dinner> FindAllDinners();
        IQueryable<Dinner> FindUpcomingDinners();
        Dinner GetDinner(int id);
        void Add(Dinner dinner);
        void Delete(Dinner dinner);
        void Save();
        IQueryable<Dinner> FindByLocation(float latitude, float longitude);
    }

    public class DinnerRepository : IDinnerRepository
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

        [DbFunction("NerdDinner.Models.Store", "DistanceBetween")]
        public static double DistanceBetween(double lat1, double long1, double lat2, double long2)
        {
            throw new NotImplementedException("Only call through LINQ expression");
        }

/*        public IQueryable<Dinner> FindByLocation(double latitude, double longitude)
        {
            return from d in _db.Dinners
                   where DistanceBetween(latitude, longitude, d.Latitude, d.Longitude) < 100
                   select d;
        }*/

        public IQueryable<Dinner> FindByLocation(float latitude, float longitude)
        {
            List<Dinner> resultList = new List<Dinner>();

            var results =
                _db.Database.SqlQuery<Dinner>(
                    "SELECT * FROM Dinners WHERE EventDate >= {0} AND dbo.DistanceBetween({1}, {2}, Latitude, Longitude) < 1000",
                    DateTime.Now, latitude, longitude);
            foreach (Dinner result in results)
            {
                resultList.Add(_db.Dinners.Where(d => d.DinnerId == result.DinnerId).FirstOrDefault());
            }

            return resultList.AsQueryable<Dinner>();
        }
    }
}