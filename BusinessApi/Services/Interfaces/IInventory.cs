using BusinessApi.Models;

namespace BusinessApi.Interfaces;

public interface IInventory
{
    //Products
    IEnumerable<Product> GetProducts();
    Product GetProductById(int id);
    Task<int> AddProduct(Product product);
    Task<int> UpdateProduct(Product product);
    Task<int> DeleteProduct(int id);

    //Inventory
    IEnumerable<InventoryItem> GetInventoryItems();
    InventoryItem GetInventoryItemById(int id);
    void AddInventoryItem(InventoryItem item);
    Task<int> UpdateInventoryItem(InventoryItem item);
    Task<int> DeleteInventoryItem(int id);

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