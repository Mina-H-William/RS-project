using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Country name is required")]
        [StringLength(100, ErrorMessage = "Country name can't be longer than 100 characters")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Country code is required")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Country code must be exactly 2 characters")]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "Country code must be 2 uppercase letters")]
        public string CountryCode { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
