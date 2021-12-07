using Microsoft.AspNetCore.Mvc;

namespace TargetProduct.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
