using Microsoft.AspNetCore.Mvc;

namespace Genevill.MVC.BugTracker.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
