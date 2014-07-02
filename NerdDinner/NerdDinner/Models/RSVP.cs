using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner.Models
{
    [Bind(Exclude = "RsvpId")]
    public class RSVP
    {
        [ScaffoldColumn(false)]
        public int RsvpId { get; set; }

        [ScaffoldColumn(false)]
        public int DinnerId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MaxLength(30)]
        public string AttendeeName { get; set; }

        // connections
        public virtual Dinner Dinner { get; set; }
    }
}