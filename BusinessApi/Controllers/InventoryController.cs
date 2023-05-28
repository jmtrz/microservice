using BusinessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    public InventoryController()
    {
        
    }

    [HttpGet]
    public ActionResult GetProducts()
    {
        var products = new Product() {
            Id = 1,
            Description = "sample data",
            Name = "Apple Pie",
            CreatedAt = new DateTime(),
            SKU = "Something"
        };

        return Ok(products);
    }

    [HttpPost]
    public ActionResult AddProduct([FromBody] Product product)
    {
        
        return Ok();
    }
}