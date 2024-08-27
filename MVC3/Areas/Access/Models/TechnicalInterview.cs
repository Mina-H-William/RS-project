namespace MVC3.Areas.Access.Models
{
    public class TechnicalInterview
    {
        public int ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        public int VacancyId { get; set; }

        public Vacancy Vacancy { get; set; }

        public string TechnicalInterviewer { get; set; }

        public bool Done { get; set; }
    }
}
