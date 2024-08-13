using Microsoft.CodeAnalysis;
using MVC3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVC3.Areas.Access.Models
{
    public partial class Location
    {
        public Location()
        {
            Projects = new HashSet<Project>();
        }

        public int LocationId { get; set; }

        [Required(ErrorMessage = "Location name is required")]
        [StringLength(100, ErrorMessage = "Location name can't be longer than 100 characters")]
        public string LocationName { get; set; }
        public int CountryId { get; set; }

        //public string CountryCode { get; set; }


        public virtual Country Country { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
