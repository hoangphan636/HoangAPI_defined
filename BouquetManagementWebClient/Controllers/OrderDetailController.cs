using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BouquetManagementWebClient.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly HttpClient client = null;
        private string productApiUrl = "";

        public OrderDetailController()
        {


            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            productApiUrl = "http://localhost:61010/api/OrderDetail";
        }
        public async Task<IActionResult> Index(int id)  ///  http://localhost:44092/FlowerBouquet/Index
        {
            string FlowerBouquetName = HttpContext.Session.GetString("CustomerName");


            if (FlowerBouquetName != null)
            {
                HttpResponseMessage response = await client.GetAsync($"{productApiUrl}/{id}");
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<OrderDetail> listProducts = JsonSerializer.Deserialize<List<OrderDetail>>(strData, options);
                return View(listProducts);

            }
         
            return RedirectToAction("Index","Loginn");


        }


        public async Task<IActionResult> Back()  ///  http://localhost:44092/Order/Index
        {

            return RedirectToAction("Index", "Order");


        }






    }
}
