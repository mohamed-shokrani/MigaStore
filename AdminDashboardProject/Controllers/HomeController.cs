using Microsoft.AspNetCore.Mvc;

namespace AdminDashboardProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
