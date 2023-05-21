﻿using BussinessObject;
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
    public class OrderController : Controller
    {

        private readonly HttpClient client = null;
        private string productApiUrl = "";

        public OrderController()
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
        public async Task<IActionResult> Create(Order p)
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


                Order product = JsonSerializer.Deserialize<Order>(root.GetRawText(), options);

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


                Order product = JsonSerializer.Deserialize<Order>(root.GetRawText(), options);

                return View(product);
            }
        }


        public async Task<IActionResult> Update(Order product)
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

                Order product = JsonSerializer.Deserialize<Order>(root.GetRawText(), options);

                return View(product);
            }

        }






    }
}
