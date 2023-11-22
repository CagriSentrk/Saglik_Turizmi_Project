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
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly Context _context;

        public AccountController(SignInManager<AppUser> signInManager, Context context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("Index");
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string adminName, string password)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(adminName, password, isPersistent: false, lockoutOnFailure: true);

            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "About"); // Başarılı giriş durumunda yönlendirilecek sayfa
            }

            return View("Login");
        }
    }
}
