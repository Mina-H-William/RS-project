using Microsoft.AspNetCore.Mvc.Rendering;
using MVC3.Areas.Identity.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC3.Areas.Identity.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<string>();
        }

        public ApplicationUser user { get; set; }

        public int? SelectedDepartmentId { get; set; }


        // To populate the multi-select dropdown
        public IEnumerable<SelectListItem> Departments { get; set; }

        // For multi-select dropdown
        public List<int>? SelectedProjectIds { get; set; } = new List<int>();

        // To populate the multi-select dropdown
        public IEnumerable<SelectListItem> Projects { get; set; }

        public IList<string> Roles { get; set; }
    }
}
