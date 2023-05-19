﻿using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using BusinessObject;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerBouquetController : ControllerBase
    {

        FlowerBouquetRepository FlowerBouquet = new FlowerBouquetRepository();
        [HttpGet]

        public ActionResult<IEnumerable<FlowerBouquet>> GetProducts() => FlowerBouquet.GetFlowerBouquet();

       

        [HttpPost]
        public ActionResult PostProduct(FlowerBouquet p)
        {
            FlowerBouquet.SaveFlowerBouquet(p);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            var product = FlowerBouquet.FindFlowerBouquetById(id);

            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(FlowerBouquet p)
        {
            var product = FlowerBouquet.FindFlowerBouquetById(p.FlowerBouquetID.Value);
            if (product == null)
            {
                return NotFound();
            }

            FlowerBouquet.UpdateFlowerBouquet(p);
            return RedirectToAction(nameof(Update), new { product });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = FlowerBouquet.FindFlowerBouquetById(id);
            if (product == null)
            {
                return NotFound();
            }

            FlowerBouquet.DeleteFlowerBouquet(product);
            return Ok();
        }
    }
}