using Microsoft.AspNetCore.Mvc;
namespace AdminDashboardProject.Controllers;
public class ProductsController : Controller
{
    public IActionResult Index()
    {

        return View();
    }
}
