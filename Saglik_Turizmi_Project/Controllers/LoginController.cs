using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Saglik_Turizmi_Project.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;

        public LoginController(SignInManager<AppUser> signInManager, Context context, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View("Login");
        }



        [HttpPost]
        public async Task<IActionResult> Register(string adminName, string password)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = adminName
                };

                var result = await _userManager.CreateAsync(user,password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login"); // Başarılı giriş durumunda yönlendirilecek sayfa
                }
                else { 
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View("Register");
        }







            [HttpPost]
        public async Task<IActionResult> Login(string adminName, string password)
        {


            //var admin = await _context.Set<Admin>().FirstOrDefaultAsync(a => a.Admin_Name == adminName);
            //if (admin != null)
            //{
            //    var signInResult = await _signInManager.PasswordSignInAsync(admin.Admin_Name, password, isPersistent: false, lockoutOnFailure: false);

            //    if (signInResult.Succeeded)
            //    {
            //        return RedirectToAction("Index", "About"); // Başarılı giriş durumunda yönlendirilecek sayfa
            //    }
            //}
            var signInResult = await _signInManager.PasswordSignInAsync(adminName, password, isPersistent: false, lockoutOnFailure: true);

            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "About"); // Başarılı giriş durumunda yönlendirilecek sayfa
            }

            // Giriş başarısız ise tekrar login sayfasına yönlendir
            return RedirectToAction("Index");
        }
    }
}
