namespace MVC3.Areas.Access.Models
{
    public class ApplicantStatus
    {
        public int ApplicantId { get; set; }

        public virtual Applicant Applicant { get; set; }

        public int VacancyId { get; set; }

        public virtual Vacancy Vacancy { get; set; }

        public bool HR { get; set; }

        public int HR_Rating { get; set; }

        public bool Technical { get; set; }

        public int Technical_rating { get; set; }


        public string Status { get; set; }
    }
}
