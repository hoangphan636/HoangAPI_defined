using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BussinessObject;
using Microsoft.AspNetCore.Http;

namespace BouquetManagementWebClient.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HttpClient client = null;
        private string productApiUrl = "";

        public CustomerController()
        {


            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            productApiUrl = "http://localhost:61010/api/Customer";
        }
        public async Task<IActionResult> Index()  ///  http://localhost:44092/Customer/Index
        {
            string customerName = HttpContext.Session.GetString("CustomerName");
           

            if (customerName != null)
            {
                HttpResponseMessage response = await client.GetAsync(productApiUrl);
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<Customer> listProducts = JsonSerializer.Deserialize<List<Customer>>(strData, options);
                return View(listProducts);

            }
            return RedirectToAction("Index", "Login");


        }

        public async Task<IActionResult> Logout() 
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
