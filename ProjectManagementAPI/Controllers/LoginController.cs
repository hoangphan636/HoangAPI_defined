using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DataAccess;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
         CustomerRepository customer = new CustomerRepository();
       
       
        [HttpGet]

        public ActionResult<IEnumerable<Customer>> GetProducts() => customer.GetCustomer();
       
        [HttpPost]
        public ActionResult PostLogin(Customer p)
        {
            var cus = customer.FindCustomerById(p.Email, p.password);
            var admin = customer.checkAdminLogin(p.Email, p.password);

            if (cus == null && admin == null)
            {
                string value = "Login Fail";
                return Ok(value);
            }

            var data = new { cus, admin };
            return Ok(cus);
        }


    }
}
