using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Saglik_Turizmi_Project.ViewComponents.Contact
{
    public class ContactList : ViewComponent
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        public IViewComponentResult Invoke()
        {
            var result = cm.TGetList();
            return View(result);
        }
    }
}
