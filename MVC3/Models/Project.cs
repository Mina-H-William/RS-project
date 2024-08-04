using System.Collections.Generic;

#nullable disable

namespace MVC3.Models
{
    public partial class Project
    {
     
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int LocationId { get; set; }
        public bool Active { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public List<VacancyProject> VacancyProjects { get; set; }
    }
}
