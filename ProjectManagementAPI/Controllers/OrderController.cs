using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementAPI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
