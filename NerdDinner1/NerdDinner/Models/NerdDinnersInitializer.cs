using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NerdDinner.Models
{
    public class NerdDinnersInitializer : DropCreateDatabaseIfModelChanges<NerdDinners>
    {
        protected override void Seed(NerdDinners context)
        {
            var dinners = new List<Dinner>
                {
                    new Dinner
                        {
                            Title = "Biscuit",
                            EventDate = DateTime.Parse("7/11/2014"),
                            Address = "Downtown Seattle",
                            Country = "Merica",
                            HostedBy = "sigotron@gmail.com"
                        }
                };

            dinners.ForEach(d => context.Dinners.Add(d));
        }
    }
}