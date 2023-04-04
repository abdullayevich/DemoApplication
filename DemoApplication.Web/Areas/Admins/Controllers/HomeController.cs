using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Web.Areas.Admins.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
