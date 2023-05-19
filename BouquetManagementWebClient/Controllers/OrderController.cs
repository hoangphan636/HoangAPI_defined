using Microsoft.AspNetCore.Mvc;

namespace BouquetManagementWebClient.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
