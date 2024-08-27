using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MVC3.Areas.Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
