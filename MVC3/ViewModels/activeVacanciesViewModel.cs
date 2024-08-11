using System.Collections.Generic;
using MVC3.Areas.Access.Models;

namespace MVC3.ViewModels
{
    public class activeVacanciesViewModel
    {
        public activeVacanciesViewModel()
        {
            locations = new List<Location>();
        }

        public int vacancyid { get; set; }

        public string vacancyname { get; set; }

        public int TotalVacancyCount { get; set; }

        public bool Active { get; set; }

        public string TitleName { get; set; }


        public List<Location> locations { get; set; }
    }
}
