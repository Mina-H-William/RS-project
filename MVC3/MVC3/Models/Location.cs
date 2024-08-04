using Microsoft.CodeAnalysis;
using MVC3.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace MVC3.Models
{
    public partial class Location
    {
        public Location()
        {
            Projects = new HashSet<Project>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int CountryId { get; set; }

        //public string CountryCode { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
