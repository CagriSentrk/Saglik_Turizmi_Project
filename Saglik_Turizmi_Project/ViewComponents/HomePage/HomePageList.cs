using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Saglik_Turizmi_Project.ViewComponents.HomePage
{
    public class HomePageList:ViewComponent
    {
        HomePageManager hm = new HomePageManager(new EfHomePageDal());
       public IViewComponentResult Invoke()
        {
            var values = hm.TGetList();

            return View(values);
        }

    }
}
