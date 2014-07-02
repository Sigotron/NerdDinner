using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<NerdDinnerEntities>
    {

        protected override void Seed(NerdDinnerEntities context)
        {
            new List<Dinner>
                {
                    new Dinner() {Address = "my house", ContactPhone = "(444) 444-4444", Country = "merica", 
                    Description = "eat food and drink beer", DinnerId = 1, EventDate = new DateTime(2014, 8, 6), HostedBy = "Joel", 
                    Latitude = (float) 1.0, Longitude = (float) 1.0},
                    new Dinner() {Address = "valhalla", ContactPhone = "(555) 455-4445", Country = "denmark", 
                    Description = "eat food and drink ale and fight", DinnerId = 2, EventDate = new DateTime(2014, 8, 7), HostedBy = "Odin", 
                    Latitude = (float) 1877.70, Longitude = (float) 778871.8880}
                }.ForEach(a => context.Dinners.Add(a));
        }

    }
}