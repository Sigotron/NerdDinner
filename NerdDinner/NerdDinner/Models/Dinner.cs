using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class Dinner
    {
        public int DinnerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        public string HostedBy { get; set; }

        [MaxLength(20)]
        public string ContractPhone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Country { get; set; }

        [Required]
        public float Latitude { get; set; }

        [Required]
        public float Longitude { get; set; }
    }
}