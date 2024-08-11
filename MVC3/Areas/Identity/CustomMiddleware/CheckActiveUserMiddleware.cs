using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MVC3.Areas.Identity.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC3.Areas.Identity.CustomMiddleware
{
    public class CheckUserActiveMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckUserActiveMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId != null)
                {
                    var user = await userManager.FindByIdAsync(userId);
                    if (user == null || !user.Active) // Assuming `Active` is the property indicating if the user is active
                    {
                        await signInManager.SignOutAsync();
                        context.Response.Redirect("/identity/account/Login"); // Redirect to a logout or login page
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}
