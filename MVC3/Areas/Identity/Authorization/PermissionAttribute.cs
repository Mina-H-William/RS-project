using Microsoft.AspNetCore.Authorization;

namespace MVC3.Areas.Identity.Authorization
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        public PermissionAttribute(string permission) : base(policy: permission)
        {}
    }
}
