using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVC3.Areas.Access.Models
{
    public partial class Project
    {
     
        public int ProjectId { get; set; }

        [Required(ErrorMessage ="Project is Required")]
        public string ProjectName { get; set; }
        public int LocationId { get; set; }
        public bool Active { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public List<VacancyProject> VacancyProjects { get; set; }
    }
}
