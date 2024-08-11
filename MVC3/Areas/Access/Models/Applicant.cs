using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MVC3.Areas.Access.Models
{
    public partial class Applicant
    {
        public Applicant()
        {
            VacancyApplicants = new HashSet<VacancyApplicant>();
        }

        public int ApplicantId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        public string ApplicantFirstName { get; set; }

        [StringLength(50)]
        public string ApplicantMiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        public string ApplicantLastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        [Phone]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Home Address is required")]
        public string HomeAddress1 { get; set; }

        public string Address2 { get; set; }

        [Required(ErrorMessage = "Nationality is required")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        public string MilitaryStatus { get; set; }

        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "Certificate Name is required")]
        public string CertificateName { get; set; }

        [Required(ErrorMessage = "Graduation Year is required")]
        public int GraduationYear { get; set; }

        [Required(ErrorMessage = "Major is required")]
        public string Major { get; set; }

        [Required(ErrorMessage = "University is required")]
        public string University { get; set; }

        public string CurrentEmployer { get; set; }

        public string CurrentPosition { get; set; }
            
        public int CurrentSalary { get; set; }

        public byte YearsOfExperience { get; set; }

        public string NoticePeriod { get; set; }

        public string ExtraCertificates { get; set; }

        //[Display(Name = "Resume")]
        //public string ResumeFilePath { get; set; }

        //[NotMapped]
        //public IFormFile Resume { get; set; }
        
        public string ResumeFilePath { get; set; } // New property for storing the file path

        [NotMapped]
        public int VacancyId { get; set; }

        public virtual ICollection<VacancyApplicant> VacancyApplicants { get; set; }
    }
}
