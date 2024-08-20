using Microsoft.AspNetCore.Identity;
using MVC3.Areas.Access.Models;
using System.Collections.Generic;


namespace MVC3.Areas.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool Active { get; set; } = true;
        public ICollection<UserDepartmentProject> UserDepartmentProject { get; set; }
    }
}
