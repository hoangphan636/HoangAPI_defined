using BussinessObject;
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
        SupplierRepository Supplier = new SupplierRepository();
        CategoryRepository Category = new CategoryRepository();
        OrderDetailRepository OrderDetail = new OrderDetailRepository();

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

        [HttpGet("custom/{id}")]
        public IActionResult CustomDetail(int id)
        {

            var product = FlowerBouquet.FindFlowerBouquetById(id);
            var supplierID = Supplier.GetSupplier();
            var category = Category.GetCategory();

            if (product == null)
            {
                return NotFound();
            }
            var learn = new FlowerBouquetFull
            {
                FlowerBouquet = product,
                Supplier = supplierID,
                Category = category
            };



            return Ok(product);
        }



        [HttpGet("custom")]
        public IActionResult CustomDetails()
        {

            
            var supplierID = Supplier.GetSupplier();
            var category = Category.GetCategory();

          
            var learn = new FlowerBouquetFull
            {
                FlowerBouquet = null,
                Supplier = supplierID,
                Category = category
            };



            return Ok(learn);
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
            var po = OrderDetail.FindFlowerBouquetById(id);
            if (product == null)
            {
                FlowerBouquet.UpdateFlowerBouquetStatus(id);
                return Ok();
            }

            if (po == null)
            {
                FlowerBouquet.DeleteFlowerBouquet(product);
                return Ok("null");
            }
           
            
            return Ok();
        }
    }
}
