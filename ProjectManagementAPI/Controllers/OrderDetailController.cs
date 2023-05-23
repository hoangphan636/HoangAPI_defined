using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {

        OrderDetailRepository OrderDetail = new OrderDetailRepository();

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<OrderDetail>> FindFlowerBouquetById(int id)
        {
          var order =  OrderDetail.FindFlowerBouquetById(id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }











    }
}
