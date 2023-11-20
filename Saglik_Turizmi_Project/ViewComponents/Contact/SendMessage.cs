using Microsoft.AspNetCore.Mvc;

namespace Saglik_Turizmi_Project.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
