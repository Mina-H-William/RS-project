using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC3.Areas.Identity.Models;

namespace MVC3.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
