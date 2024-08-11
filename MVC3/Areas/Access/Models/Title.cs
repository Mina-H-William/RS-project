using MVC3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVC3.Areas.Access.Models
{
    public partial class Title
    {
        public Title()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public int TitleId { get; set; }

        [Required]
        public string TitleName { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
