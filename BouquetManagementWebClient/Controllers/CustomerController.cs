using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using BussinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

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
            string Email = HttpContext.Session.GetString("Email");
           

            if (Email != null && Email.Equals("admin@FURentalSystem.com"))
            {
                HttpResponseMessage response = await client.GetAsync(productApiUrl);
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<Customer> listProducts = JsonSerializer.Deserialize<List<Customer>>(strData, options);
                return View(listProducts);

            }else if (Email != null && !Email.Equals("admin@FURentalSystem.com"))
            {
                HttpResponseMessage response = await client.GetAsync($"{productApiUrl}/{"email"}/{Email}");
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
        public async Task<IActionResult> Flowerbouquet()  ///  http://localhost:44092/Customer/Index
        {
          
            return RedirectToAction("Index", "FlowerBouquet");


        }

        public async Task<IActionResult> Order()  ///  http://localhost:44092/Customer/Index
        {

            return RedirectToAction("Index", "Order");


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
        public async Task<IActionResult> Create(Customer p)
        {
            string Email = HttpContext.Session.GetString("Email");


            if (Email != null)
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
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction("Index", "Login");
        }

        public async Task<IActionResult> Details(int id)
        {
            string Email = HttpContext.Session.GetString("Email");
            if (Email != null)
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


                    Customer product = JsonSerializer.Deserialize<Customer>(root.GetRawText(), options);

                    return View(product);
                }
            }
            return RedirectToAction("Index", "Login");
        }

        public async Task<IActionResult> Edit(int id)
        {
            string Email = HttpContext.Session.GetString("Email");
            if (Email != null)
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


                    Customer product = JsonSerializer.Deserialize<Customer>(root.GetRawText(), options);

                    return View(product);
                }
            }
            return RedirectToAction("Index", "Login");
        }


        public async Task<IActionResult> Update(Customer product)
        {
            string Email = HttpContext.Session.GetString("Email");
            if (Email != null)
            {
                var json = JsonSerializer.Serialize(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{productApiUrl}/{product.CustomerID}", content);
                if (response.IsSuccessStatusCode)
                {
                    string strData = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var createdProduct = JsonSerializer.Deserialize<Customer>(strData, options);

                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Login");
        }


        public async Task<IActionResult> Deleted(int id)
        {
            string Email = HttpContext.Session.GetString("Email");
            if (Email != null)
            {
                HttpResponseMessage response = await client.DeleteAsync($"{productApiUrl}/{id}");
                string strData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction("Index", "Login");
        }

            public async Task<IActionResult> Delete(int id)
        {
            string Email = HttpContext.Session.GetString("Email");
            if (Email != null)
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

                    Customer product = JsonSerializer.Deserialize<Customer>(root.GetRawText(), options);

                    return View(product);
                }
            }
            return RedirectToAction("Index", "Login");

        }
    }
}
