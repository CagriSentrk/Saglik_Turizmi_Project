using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Saglik_Turizmi_Project.Controllers
{
    public class DefaultController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(Message p)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());
            p.Message_date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Message_Status = true;
            messageManager.TAdd(p);

            return RedirectToAction("Index");
        }

     
    }
}
