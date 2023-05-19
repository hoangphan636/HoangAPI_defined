using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerRepository customer = new CustomerRepository();
        [HttpGet]

        public ActionResult<IEnumerable<Customer>> GetProducts() => customer.GetCustomer();
    }
}
