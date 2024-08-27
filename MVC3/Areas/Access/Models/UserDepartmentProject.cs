using MVC3.Areas.Identity.Models;

namespace MVC3.Areas.Access.Models
{
    public class UserDepartmentProject
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }


    }
}
