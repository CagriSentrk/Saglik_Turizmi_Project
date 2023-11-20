using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Saglik_Turizmi_Project.Controllers
{
    public class MessageController : Controller
    {
        MessageManager MessageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
           
           
                var values = MessageManager.TGetList();
                return View(values);
            
            return View();
         
        }

        public IActionResult MessageDetails(int id)
        {

            var values = MessageManager.TGetByID(id);
            return View(values);

        }
        public IActionResult DeleteService(int id)
        {
            var values = MessageManager.TGetByID(id);
            MessageManager.TDelete(values);
            return RedirectToAction("Index");
        }


    }
}
