using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Saglik_Turizmi_Project.Controllers
{
  
    public class AboutController : Controller
    {
        AboutManager AboutManager = new AboutManager(new EfAboutDal());
        public IActionResult Index()
        {
            var values = AboutManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditAbout(int id)
        {

            var values = AboutManager.TGetByID(id);
            return View(values);

        }

        [HttpPost]

        public IActionResult EditAbout(About p)
        {
            AboutManager.TUpdate(p);
            return RedirectToAction("Index");
        }


    }
}
