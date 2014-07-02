using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner.Models
{
    [Bind(Exclude = "DinnerId")]
    public class Dinner
    {
        [ScaffoldColumn(false)]
        public int DinnerId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MaxLength(256)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MaxLength(20)]
        public string HostedBy { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MaxLength(20)]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MaxLength(20)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public float Latitude { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public float Longitude { get; set; }
    }
}