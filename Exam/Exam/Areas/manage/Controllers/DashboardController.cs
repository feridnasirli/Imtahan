using Exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Areas.manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser user = new AppUser
        //    {
        //        FullName = "Ferid Nesirli",
        //        UserName = "SuperAdmin"
        //    };
        //    var result=await _userManager.CreateAsync(user,"Ferid2003");
        //     return Ok("create");
        //}
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role = new IdentityRole("SuperAdmin");
        //    IdentityRole role1 = new IdentityRole("Admin");

        //    await _roleManager.CreateAsync(role);
        //    await _roleManager.CreateAsync(role);
        //     return Ok("create");

        //}
    }
}
