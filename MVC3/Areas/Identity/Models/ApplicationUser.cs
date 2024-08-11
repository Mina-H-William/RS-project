using Microsoft.AspNetCore.Identity;


namespace MVC3.Areas.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool Active { get; set; } = true;
    }
}
