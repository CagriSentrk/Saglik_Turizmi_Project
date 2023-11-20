using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Saglik_Turizmi_Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<Admin> _signInManager;
        private readonly DbContext _context;

        public LoginController(SignInManager<Admin> signInManager, DbContext context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string adminName, string password)
        {
            var admin = await _context.Set<Admin>().FindAsync(adminName);
            if (admin != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(admin.Admin_Name, password, isPersistent: false, lockoutOnFailure: false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "About"); // Başarılı giriş durumunda yönlendirilecek sayfa
                }
            }

            // Giriş başarısız ise tekrar login sayfasına yönlendir
            return RedirectToAction("Index");
        }
    }
}
