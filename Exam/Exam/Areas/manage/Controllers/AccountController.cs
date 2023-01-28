using Exam.Areas.manage.ViewModels;
using Exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> Login(AdminLoginViewModel adminLogin)
        {
            AppUser user =await _userManager.FindByNameAsync(adminLogin.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Password and UserName");
                return View();
            }
            var result =await _signInManager.PasswordSignInAsync(user, adminLogin.Password,false,false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Password and UserName");
                return View();
            }
            return RedirectToAction("index","dashboard");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("login", "account");
        }
    }
}
