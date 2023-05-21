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
    public class OrderController : ControllerBase
    {

        CustomerRepository Customer = new CustomerRepository();
        OrderRepository Order = new OrderRepository();
        [HttpGet]

        public ActionResult<IEnumerable<Order>> GetProducts() => Order.GetOrder();

        [HttpPost]
        public ActionResult PostProduct(Order p)
        {
            Order.SaveOrder(p);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            var product = Order.FindOrderById(id);

            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Order p)
        {
            var product = Order.FindOrderById(p.OrderID.Value);
            if (product == null)
            {
                return NotFound();
            }

            Order.UpdateOrder(p);
            return RedirectToAction(nameof(Update), new { product });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = Order.FindOrderById(id);
            if (product == null)
            {
                return NotFound();
            }

            Order.DeleteOrder(product);
            return Ok();
        }

        [HttpGet("OrderFlower")]
        public IActionResult CustomDetails()
        {


            var Customers = Customer.GetCustomer();
          


            var learn = new CustomerFul
            {
                FlowerBouquet = null,
                Customer = Customers,
              
            };



            return Ok(learn);
        }





    }
}
