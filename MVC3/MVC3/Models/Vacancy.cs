using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MVC3.Models
{
    public partial class Vacancy
    {
        public int VacancyId { get; set; }
        public string VacancyName { get; set; }
        public int? TotalVacancyCount { get; set; }
        public int TitleId { get; set; }
        public bool Active { get; set; }

        public virtual Title Title { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public List<VacancyProject> VacancyProjects { get; set; }

        [NotMapped]
        public int[] SelectedProjectIds { get; set; } // Property to hold the selected Project ID

        public DateTime? LastUpdated { get; set; }

        public String AddedBy {  get; set; }
    }
}
