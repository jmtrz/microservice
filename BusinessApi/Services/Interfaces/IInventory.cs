using BusinessApi.Models;

namespace BusinessApi.interfaces;

public interface IInventory
{
    //Products
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProductById();
    Task<int> AddProduct(Product product);
    Task<int> UpdateProduct(Product product);
    Task<int> DeleteProduct(int id);

    //Inventory
    Task<IEnumerable<InventoryItem>> GetInventoryItems();
    Task<InventoryItem> GetInventoryItemById();
    Task<int> AddInventoryItem();
    Task<int> UpdateInventoryItem();
    Task<int> DeleteInventoryItem();

    //Orders
    Task<IEnumerable<Order>> GetOrders();
    Task<Order> GetOrderById(int id);
    Task<int> AddOrder(Order order);
    Task<int> UpdateOrder(Order order);
    Task<int> DeleteOrder(int id);

    //OrderItems
    Task<IEnumerable<OrderItem>> GetOrderItems();
    Task<OrderItem> GetOrderItemById();
    Task<int> AddOrderItem();
    Task<int> UpdateOrderItem();
    Task<int> DeleteOrderItem();
}