using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessApi.Dtos;
using BusinessApi.Interfaces;
using BusinessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IInventory _inventory;

        public ProductsController(IInventory inventory)
        {
            _inventory = inventory;
        }
        [HttpGet("get-all")]
        public ActionResult GetProducts()
        {
            return Ok(_inventory.GetProducts());
        } 

        [HttpGet("get-by-id/{id}")]
        public ActionResult GetProductsById([FromRoute] string id)
        {
            return Ok(_inventory.GetProductById(id) ?? null);
        }

        [HttpPost("new-product")]
        public ActionResult AddProducts([FromBody] Product product)
        {
            // string response = product is null ? "something was added": "null content";
            _inventory.AddProduct(product);
            return Ok("Added Successfully");
        }

        [HttpPut("update-product")]
        public ActionResult UpdateProducts([FromBody] Product product)
        {            
            return Ok(_inventory.UpdateProduct(product));
        }

        [HttpDelete("delete-product/{id}")]
        public ActionResult DeleteProduct([FromRoute] string id)
        {
            return Ok(_inventory.DeleteProduct(id)) ?? Ok("None");            
        }
    }
}