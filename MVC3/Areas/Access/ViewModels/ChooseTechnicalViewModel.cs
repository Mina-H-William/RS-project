using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using MVC3.Areas.Identity.Models;

namespace MVC3.Areas.Access.ViewModels
{
    public class ChooseTechnicalViewModel
    {
        public string departmentname { get; set; }

        public int Applicantid { get; set; }

        public int Vacancyid { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}
