using Microsoft.AspNetCore.Mvc;

namespace BouquetManagementWebClient.Controllers
{
    public class OrderDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
