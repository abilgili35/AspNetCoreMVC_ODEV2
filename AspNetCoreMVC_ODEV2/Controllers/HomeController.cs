using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC_ODEV2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
