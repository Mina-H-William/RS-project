using MVC3.Areas.Access.Models;

namespace MVC3.Areas.Access.ViewModels
{
    public class TechnicalInteviewViewModel
    {
        public int Applicantid { get; set; }

        public Applicant Applicant { get; set; }

        public int Vacancyid { get; set; }

        public Vacancy Vacancy { get; set; }

        public bool Done { get; set; }
    }
}
