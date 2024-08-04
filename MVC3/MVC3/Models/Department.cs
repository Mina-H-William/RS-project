using System;
using System.Collections.Generic;

#nullable disable


namespace MVC3.Models
{
    public partial class Department
    {
        public Department()
        {
            Titles = new HashSet<Title>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }

        public virtual ICollection<Title> Titles { get; set; }
    }
}
