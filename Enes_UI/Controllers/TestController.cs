using Microsoft.AspNetCore.Mvc;

namespace Enes_UI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
