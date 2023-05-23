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
using System;

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
            HttpContext.Session.Remove("message");
            return RedirectToAction("Index", "Login");


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


            if (Email != null)
            {
                HttpResponseMessage response = await client.GetAsync($"{productApiUrl}/custom");

                string strData = response.Content.ReadAsStringAsync().Result;

                using (JsonDocument document = JsonDocument.Parse(strData))
                {
                    JsonElement root = document.RootElement;
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    JsonElement supplierElement = root.GetProperty("supplier");
                    JsonElement categoryElement = root.GetProperty("category");

                    List<Category> categories = JsonSerializer.Deserialize<List<Category>>(categoryElement.GetRawText(), options);
                    List<Supplier> suppliers = JsonSerializer.Deserialize<List<Supplier>>(supplierElement.GetRawText(), options);

                    ViewBag.CategoryId = new SelectList(categories, nameof(Category.CategoryID), nameof(Category.CategoryName));
                    ViewBag.SupplierID = new SelectList(suppliers, nameof(Supplier.SupplierID), nameof(Supplier.SupplierName));
                    HttpContext.Session.Remove("message");
                    return View();
                }
            }
            return RedirectToAction("Index", "Login");
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlowerBouquet p)
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
                HttpContext.Session.Remove("message");
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


                    FlowerBouquet product = JsonSerializer.Deserialize<FlowerBouquet>(root.GetRawText(), options);
                    HttpContext.Session.Remove("message");
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
                HttpResponseMessage response = await client.GetAsync($"{productApiUrl}/custom/{id}");
                string strData = await response.Content.ReadAsStringAsync();

                using (JsonDocument document = JsonDocument.Parse(strData))
                {
                    JsonElement root = document.RootElement;
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };


                    FlowerBouquet product = JsonSerializer.Deserialize<FlowerBouquet>(root.GetRawText(), options);
                    HttpContext.Session.Remove("message");
                    return View(product);
                }
            }
            return RedirectToAction("Index", "Login");

        }


        public async Task<IActionResult> Update(FlowerBouquet product)
        {
            string Email = HttpContext.Session.GetString("Email");


            if (Email != null)
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
                HttpContext.Session.Remove("message");
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Login");
        }


        public async Task<IActionResult> Deleted(int id)
        {
            string Email = HttpContext.Session.GetString("Email");


            if (Email != null)
            {
                HttpResponseMessage responses = await client.DeleteAsync($"{productApiUrl}/{id}");
                string strDatas = await responses.Content.ReadAsStringAsync();
                if (!strDatas.Equals("\"null\""))
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
                        string message = "The Order Still exist, so can not delete";
                        HttpContext.Session.SetString("message", message);

                        return RedirectToAction(nameof(Index));

                    }

                }
                HttpContext.Session.Remove("message");
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

                    FlowerBouquet product = JsonSerializer.Deserialize<FlowerBouquet>(root.GetRawText(), options);
                    HttpContext.Session.Remove("message");
                    return View(product);
                }
            }
            return RedirectToAction("Index", "Login");

        }
    }
}
