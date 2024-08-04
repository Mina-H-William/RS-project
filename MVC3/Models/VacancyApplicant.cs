using System;

#nullable disable

namespace MVC3.Models
{
    public partial class VacancyApplicant
    {
        public int ApplicantId { get; set; }
        public int VacancyId { get; set; }
        public int ExpectedSalary { get; set; }
        public string HearAboutVacancy { get; set; }
        public string WorkAtCompany { get; set; }
        public string RelativeAtCompany { get; set; }
        public int LocationId { get; set; }

        public virtual Applicant Applicant { get; set; }
        public virtual Vacancy Vacancy { get; set; }
        public virtual Location Location { get; set; }
    }
}
