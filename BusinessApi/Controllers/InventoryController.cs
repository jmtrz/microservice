using BusinessApi.Interfaces;
using BusinessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Controllers;

[ApiController]
[Route("api/inventory")]
public class InventoryController : ControllerBase
{
    private readonly IInventory _Inventory;

    public InventoryController(IInventory Inventory)
    {
        _Inventory = Inventory;
    }

    [HttpGet]
    public ActionResult GetInventoryItems() => Ok(_Inventory.GetInventoryItems());

    [HttpGet("{id}")]
    public ActionResult GetInventoryItemById(string id) => Ok(_Inventory.GetInventoryItemById(id));

    [HttpPost]
    public ActionResult AddInventoryItem([FromBody] InventoryItem inventoryItem)
    {
        _Inventory.AddInventoryItem(inventoryItem);
        return Ok("Inventory Added Successfully");
    }

    [HttpPut]
    public ActionResult UpdateProduct([FromBody] InventoryItem inventoryItem)
    {
        _Inventory.UpdateInventoryItem(inventoryItem);
        
        return Ok("Inventory Updated Successfully");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(string id)
    {
        return Ok();
    }
}