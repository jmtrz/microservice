using BusinessApi.Dtos;
using BusinessApi.Models;

namespace BusinessApi.Interfaces;

public interface IInventory
{
    //Products
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProductById(string id);
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string id);

    //Inventory
    IEnumerable<InventoryItem> GetInventoryItems();
    InventoryItem GetInventoryItemById(string id);
    void AddInventoryItem(InventoryItem item);
    Task<int> UpdateInventoryItem(InventoryItem item);
    Task<int> DeleteInventoryItem(string id);

    //Orders
    IEnumerable<Order> GetOrders();
    Order GetOrderById(int id);
    Task<int> AddOrder(Order order);
    Task<int> UpdateOrder(Order order);
    Task<int> DeleteOrder(int id);

    //OrderItems
    IEnumerable<OrderItem> GetOrderItems();
    OrderItem GetOrderItemById(int id);
    Task<int> AddOrderItem(OrderItem orderItem);
    Task<int> UpdateOrderItem(OrderItem orderItem);
    Task<int> DeleteOrderItem(int id);
}