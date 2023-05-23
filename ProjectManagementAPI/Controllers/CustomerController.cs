using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerRepository customer = new CustomerRepository();
        [HttpGet]

        public ActionResult<IEnumerable<Customer>> GetProducts() => customer.GetCustomer();

        [HttpPost]
        public ActionResult PostProduct(Customer p)
        {
            customer.SaveCustomer(p);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            var product = customer.FindCustomerById(id);
          
            if (product == null)
            {
                return NotFound();
            }

          

            return Ok(product);
        }


        [HttpGet("email/{email}")]
        public IActionResult Details(string email)
        {
            var product = customer.FindCustomerByEmail(email);

            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }



        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Customer p)
        {
            var product = customer.FindCustomerById(p.CustomerID.Value);
            if (product == null)
            {
                return NotFound();
            }

            customer.UpdateCustomer(p);
            return RedirectToAction(nameof(Update), new { product });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = customer.FindCustomerById(id);
            if (product == null)
            {
                return NotFound();
            }

            customer.DeleteCustomer(product);
            return Ok();
        }

    }
}
