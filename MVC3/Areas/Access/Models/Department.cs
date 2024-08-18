using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable


namespace MVC3.Areas.Access.Models
{
    public partial class Department
    {
        public Department()
        {
            Titles = new HashSet<Title>();
        }

        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department name is required")]
        [StringLength(100, ErrorMessage = "Department name can't be longer than 100 characters")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Department code is required")]
        [StringLength(10, ErrorMessage = "Department code can't be longer than 10 characters")]
        public string DepartmentCode { get; set; }


        public virtual ICollection<Title> Titles { get; set; }

        public ICollection<DepartmentUser> DepartmentUsers { get; set; }
    }
}
