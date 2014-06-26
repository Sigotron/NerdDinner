using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner
{
    public class Dinner
    {
        public int DinnerID { get; set; }
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public string Address { get; set; }
        public string HostedBy { get; set; }
        public string Country { get; set; }

        // virtual implies lazy loadinf which means that RSVPs 
        // won't load until the first time it is accessed
        public virtual ICollection<RSVP> RSVPs { get; set; }
    }
}