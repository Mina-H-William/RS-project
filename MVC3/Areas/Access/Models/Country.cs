using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

#nullable disable

namespace MVC3.Areas.Access.Models
{
    public partial class Country
    {
        public Country()
        {
            Locations = new HashSet<Location>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
