using BusinessApi.Interfaces;
using BusinessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventory _Inventory;

    public InventoryController(IInventory Inventory)
    {
        _Inventory = Inventory;
    }

    [HttpGet]
    public ActionResult GetProducts() => Ok(_Inventory.GetProducts());

    [HttpPost]
    public ActionResult AddProduct([FromBody] Product product)
    {
        
        return Ok();
    }
}