using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetOrders()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetOrderById(string id)
        {
            return Ok();            
        }

        [HttpPut]
        public ActionResult UpdateOrder([FromBody] Order order)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult AddOrder()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            return Ok();
        }
    }
}