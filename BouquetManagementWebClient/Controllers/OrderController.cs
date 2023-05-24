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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BouquetManagementWebClient.Controllers
{
    public class OrderController : Controller
    {

        private readonly HttpClient client = null;
        private string productApiUrl = "";

        public OrderController()
        {


            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            productApiUrl = "http://localhost:61010/api/Order";
        }
        public async Task<IActionResult> Index()  ///  http://localhost:44092/FlowerBouquet/Index
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
                List<Order> listProducts = JsonSerializer.Deserialize<List<Order>>(strData, options);
                return View(listProducts);

            }
            else if (Email != null && !Email.Equals("admin@FURentalSystem.com"))
            {
                HttpResponseMessage response = await client.GetAsync($"{productApiUrl}/{"emails"}/{Email}");
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<Order> listProducts = JsonSerializer.Deserialize<List<Order>>(strData, options);
               
                return View(listProducts);

            }
                HttpContext.Session.Remove("message");
            return RedirectToAction("Index", "Login");


        }
        public async Task<IActionResult> Flowerbouquet()  ///  http://localhost:44092/Order/Index
        {

            return RedirectToAction("Index", "FlowerBouquet");


        }

        public async Task<IActionResult> OrderDetail(int id)  ///  http://localhost:44092/Order/Index
        {

            return RedirectToAction("Index", "OrderDetail", new { id });


        }




        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        public async Task<IActionResult> Back()
        {

            return RedirectToAction("Index", "Customer");
        }

        public async Task<IActionResult> Create()
        {
            string Email = HttpContext.Session.GetString("Email");

            if (Email != null && Email.Equals("admin@FURentalSystem.com"))
            {
                HttpResponseMessage response = await client.GetAsync($"{productApiUrl}/OrderFlower");

                string strData = response.Content.ReadAsStringAsync().Result;

                using (JsonDocument document = JsonDocument.Parse(strData))
                {
                    JsonElement root = document.RootElement;
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    JsonElement supplierElement = root.GetProperty("customer");



                    List<Customer> suppliers = JsonSerializer.Deserialize<List<Customer>>(supplierElement.GetRawText(), options);


                    ViewBag.customerID = new SelectList(suppliers, nameof(Customer.CustomerID), nameof(Customer.CustomerName));
                    HttpContext.Session.Remove("message");
                    return View();
                }
            }
            else if (Email != null && !Email.Equals("admin@FURentalSystem.com"))
            {
                HttpResponseMessage response = await client.GetAsync($"{productApiUrl}/{"Mail"}/{Email}");
                string strData = response.Content.ReadAsStringAsync().Result;

                using (JsonDocument document = JsonDocument.Parse(strData))
                {
                    JsonElement root = document.RootElement;
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    Customer customer = JsonSerializer.Deserialize<Customer>(root.GetRawText(), options);
                    List<Customer> suppliers = new List<Customer> { customer };

                    ViewBag.customerID = new SelectList(suppliers, nameof(Customer.CustomerID), nameof(Customer.CustomerName));
                    HttpContext.Session.Remove("message");
                    return View();
                }

            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order p)
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
                }
                return RedirectToAction(nameof(Index));
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


                    Order product = JsonSerializer.Deserialize<Order>(root.GetRawText(), options);

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


                    Order product = JsonSerializer.Deserialize<Order>(root.GetRawText(), options);

                    return View(product);
                }
            }
            return RedirectToAction("Index", "Login");
        }


        public async Task<IActionResult> Update(Order product)
        {
            string Email = HttpContext.Session.GetString("Email");


            if (Email != null)
            {
                var json = JsonSerializer.Serialize(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync($"{productApiUrl}/{product.OrderID}", content);
                if (response.IsSuccessStatusCode)
                {
                    string strData = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var createdProduct = JsonSerializer.Deserialize<Order>(strData, options);

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

                    Order product = JsonSerializer.Deserialize<Order>(root.GetRawText(), options);

                    return View(product);
                }


            }
            return RedirectToAction("Index", "Login");
        }






    }
}
