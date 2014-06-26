using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NerdDinner
{
    public class Dinner
    {
        public int DinnerID { get; set; }

        [Required(ErrorMessage="Please enter a Dinner Title")]
        [StringLength(50, ErrorMessage="Title is too long")]
        public string Title { get; set; }

        [Required(ErrorMessage="Please enter the Date of the Dinner")]
        public DateTime EventDate { get; set; }

        [StringLength(256, ErrorMessage="Description is too long")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string HostedBy { get; set; }

        [StringLength(20, ErrorMessage = "ContactPhone is too long")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "Please enter the location of the Dinner")]
        [StringLength(30, ErrorMessage = "Address is too long")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the country")]
        [StringLength(20, ErrorMessage = "Country is too long")]
        public string Country { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        // virtual implies lazy loadinf which means that RSVPs 
        // won't load until the first time it is accessed
        public virtual ICollection<RSVP> RSVPs { get; set; }
    }
}