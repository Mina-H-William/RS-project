using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MVC3.Areas.Access.Models
{
    public partial class Vacancy
    {
        public int VacancyId { get; set; }

        [Required]
        public string VacancyName { get; set; }

        [Required]
        [Range(1,1000)]
        public int TotalVacancyCount { get; set; }
        public int TitleId { get; set; }
        public bool Active { get; set; }

        public string AddedBy { get; set; }

        public DateTime AddedTime { get; set; } = DateTime.Now;

        public virtual Title Title { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public List<VacancyProject> VacancyProjects { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select at least one project.")]
        public int[] SelectedProjectIds { get; set; } // Property to hold the selected Project ID

        public DateTime? LastUpdated { get; set; }

        public virtual ICollection<ApplicantAnswers> ApplicantAnswers { get; set; }

        public virtual ICollection<ApplicantStatus> ApplicantStatus { get; set; }

        public virtual ICollection<TechnicalInterview> TechnicalInterviews { get; set; }



    }
}
