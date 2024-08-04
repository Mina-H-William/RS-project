using MVC3.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace MVC3.Models
{
    public partial class VacancyProject
    {
        public int VacancyId { get; set; }
        public int ProjectId { get; set; }
        public int? VacancyCount { get; set; }

        public virtual Project Project { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}
