using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Saglik_Turizmi_Project.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager sm = new ServiceManager(new EfServiceDal());
        public IActionResult Index(int id)
        {
         
            var result = sm.TGetByID(id);
            ViewBag.Title = result.Service_Id;
            return View(new List<Service> { result });
        }

        public IActionResult ServiceList()
        {
            var values = sm.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service p)
        {
            sm.TAdd(p);
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {

            var values = sm.TGetByID(id);
            return View(values);

        }

        [HttpPost]

        public IActionResult EditService(Service p)
        {
            sm.TUpdate(p);
            return RedirectToAction("ServiceList");
        }
        public IActionResult DeleteService(int id)
        {
            var values = sm.TGetByID(id);
            sm.TDelete(values);
            return RedirectToAction("ServiceList");
        }

    }
}
