using Microsoft.AspNetCore.Mvc;

namespace Enes_UI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
