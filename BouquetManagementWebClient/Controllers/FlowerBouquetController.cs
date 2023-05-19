using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace BouquetManagementWebClient.Controllers
{
    public class FlowerBouquetController : Controller
    {
        private readonly HttpClient client = null;
        private string productApiUrl = "";

        public FlowerBouquetController()
        {


            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            productApiUrl = "http://localhost:61010/api/FlowerBouquet";
        }
        public async Task<IActionResult> Index()  ///  http://localhost:44092/FlowerBouquet/Index
        {
            string FlowerBouquetName = HttpContext.Session.GetString("CustomerName");


            if (FlowerBouquetName != null)
            {
                HttpResponseMessage response = await client.GetAsync(productApiUrl);
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<FlowerBouquet> listProducts = JsonSerializer.Deserialize<List<FlowerBouquet>>(strData, options);
                return View(listProducts);

            }
            return RedirectToAction("Index", "Login");


        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlowerBouquet p)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(p);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(productApiUrl, contentData);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Insert successfully!";
                }
                else
                {
                    ViewBag.Message = "Error while calling WebAPI!";
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{productApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();

            using (JsonDocument document = JsonDocument.Parse(strData))
            {
                JsonElement root = document.RootElement;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };


                FlowerBouquet product = JsonSerializer.Deserialize<FlowerBouquet>(root.GetRawText(), options);

                return View(product);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{productApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();

            using (JsonDocument document = JsonDocument.Parse(strData))
            {
                JsonElement root = document.RootElement;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };


                FlowerBouquet product = JsonSerializer.Deserialize<FlowerBouquet>(root.GetRawText(), options);

                return View(product);
            }
        }


        public async Task<IActionResult> Update(FlowerBouquet product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"{productApiUrl}/{product.FlowerBouquetID}", content);
            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var createdProduct = JsonSerializer.Deserialize<FlowerBouquet>(strData, options);

            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Deleted(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{productApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{productApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();

            using (JsonDocument document = JsonDocument.Parse(strData))
            {
                JsonElement root = document.RootElement;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Lấy đối tượng "product" từ JSON

                FlowerBouquet product = JsonSerializer.Deserialize<FlowerBouquet>(root.GetRawText(), options);

                return View(product);
            }

        }
    }
}
