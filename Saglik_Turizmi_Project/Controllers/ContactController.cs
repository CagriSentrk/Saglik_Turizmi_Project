using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Saglik_Turizmi_Project.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        public IActionResult Index()
        {
            var values = cm.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditContact(int id)
        {

            var values = cm.TGetByID(id);
            return View(values);

        }

        [HttpPost]

        public IActionResult EditContact(Contact p)
        {
            cm.TUpdate(p);
            return RedirectToAction("Index");
        }

    }
}
