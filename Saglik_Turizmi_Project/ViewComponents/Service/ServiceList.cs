using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Saglik_Turizmi_Project.ViewComponents.Service
{
    public class ServiceList:ViewComponent

    {
        ServiceManager sm = new ServiceManager(new EfServiceDal());
        public IViewComponentResult Invoke()
        {
            var values = sm.TGetList();

            return View(values);
        }
    }
}
