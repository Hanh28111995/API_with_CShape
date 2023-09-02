using Microsoft.AspNetCore.Mvc;

namespace wcl_employee_admin.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
