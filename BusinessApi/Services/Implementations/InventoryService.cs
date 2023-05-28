using BusinessApi.Data;
using BusinessApi.Dtos;
using BusinessApi.Interfaces;
using BusinessApi.Models;

namespace BusinessApi.Services.Implementations;

public class InventoryService : IInventory
{
    private readonly InventoryDbContext _context;

    public InventoryService(InventoryDbContext context)
    {
        _context = context;
    }
    public void AddInventoryItem(InventoryItem item)
    {
        if(item is null) throw new ArgumentNullException(nameof(item));

        _context.InventoryContext?.Add(item);
        _context.SaveChanges();
    }

    public Task<int> AddOrder(Order order)
    {
        if(order is null) throw new ArgumentNullException(nameof(order));

        _context.OrdersContext?.Add(order);
        return _context.SaveChangesAsync();
    }

    public Task<int> AddOrderItem(OrderItem orderItem)
    {
        if(orderItem is null) throw new ArgumentNullException(nameof(orderItem));

        _context.OrderItemsContext?.Add(orderItem);
        return _context.SaveChangesAsync();
    }

    public Task<int> AddProduct(Product product)
    {
        if(product is null) throw new ArgumentNullException(nameof(product));
        _context.ProductsContext?.Add(product);
        return _context.SaveChangesAsync();
    }

    public Task<int> DeleteInventoryItem(int id)
    {
        var item = _context.InventoryContext?.Find(id);
        if ( item is null)
            throw new KeyNotFoundException();

        _context.Remove(item);
        return _context.SaveChangesAsync();
    }

    public Task<int> DeleteOrder(int id)
    {
        var order = _context.OrdersContext?.Find(id);
        if(order is null)
            throw new KeyNotFoundException();
        
        _context.Remove(order);
        return _context.SaveChangesAsync();
    }

    public Task<int> DeleteOrderItem(int id)
    {
        var orderItem = _context.OrderItemsContext?.Find(id);
        if(orderItem is null)
            throw new KeyNotFoundException();
        
        _context.Remove(orderItem);
        return _context.SaveChangesAsync();
    }

    public Task<int> DeleteProduct(int id)
    {
        var product = _context.ProductsContext?.Find(id);

        if(product is null)
            throw new KeyNotFoundException();
        
        _context.Remove(id);
        return _context.SaveChangesAsync();
    }

    public InventoryItem GetInventoryItemById(int id)
    {
        return _context.InventoryContext?.Find(id) ?? new InventoryItem();
    }

    public IEnumerable<InventoryItem> GetInventoryItems()
    {
        return _context.InventoryContext?.ToList() ?? new List<InventoryItem>();
    }

    public Order GetOrderById(int id)
    {
        return _context.OrdersContext?.Find(id) ?? new Order();
    }

    public OrderItem GetOrderItemById(int id)
    {
        return _context.OrderItemsContext?.Find(id) ?? new OrderItem();
    }

    public IEnumerable<OrderItem> GetOrderItems()
    {
        return _context.OrderItemsContext?.ToList() ?? new List<OrderItem>();
    }

    public IEnumerable<Order> GetOrders()
    {
        return _context.OrdersContext?.ToList() ?? new List<Order>();
    }

    public Product GetProductById(int id)
    {
        return _context.ProductsContext?.Find(id) ?? new Product();
    }

    public IEnumerable<Product> GetProducts()
    {
        return _context.ProductsContext?.ToList() ?? new List<Product>();
    }

    public Task<int> UpdateInventoryItem(InventoryItem item)
    {
       var existingItem = _context.InventoryContext?.Find(item.Id);
       if (existingItem != null) 
       {
            existingItem.Location = item.Location;
            existingItem.Quantity = item.Quantity;

            return _context.SaveChangesAsync();
       }
       else
       {
            return Task.FromResult(0);
       }
    }

    public Task<int> UpdateOrder(Order order)
    {
        var existingOrder = _context.OrdersContext?.Find(order.Id);
        if (existingOrder != null)
        {
            existingOrder.CustomerName = order.CustomerName;
            existingOrder.Status = order.Status;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.TotalPrice = order.TotalPrice;

            return _context.SaveChangesAsync();
        }

        return Task.FromResult(0);
    }

    public Task<int> UpdateOrderItem(OrderItem orderItem)
    {
        var existingOrderItem = _context.OrderItemsContext?.Find(orderItem.Id);

        if(existingOrderItem != null)
        {
            existingOrderItem.Price = orderItem.Price;
            existingOrderItem.Quantity = orderItem.Quantity;
            return _context.SaveChangesAsync();
        }

        return Task.FromResult(0);
    }

    public Task<int> UpdateProduct(Product product)
    {
        var existingProduct = _context.ProductsContext?.Find(product.Id);
        if(existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.SKU = product.SKU;
            existingProduct.UpdatedAt = product.UpdatedAt;

            _context.SaveChangesAsync();
        }

        return Task.FromResult(0);
    }
}