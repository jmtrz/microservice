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

    #region Add InventoryItem | Order | OrderItem | Product
    public void AddInventoryItem(InventoryItem item)
    {
        if(item is null) throw new ArgumentNullException(nameof(item));

        _context.Inventory?.Add(item);
        _context.SaveChanges();
    }

    public Task<int> AddOrder(Order order)
    {
        if(order is null) throw new ArgumentNullException(nameof(order));

        _context.Orders?.Add(order);
        return _context.SaveChangesAsync();
    }

    public Task<int> AddOrderItem(OrderItem orderItem)
    {
        if(orderItem is null) throw new ArgumentNullException(nameof(orderItem));

        _context.OrderItems?.Add(orderItem);
        return _context.SaveChangesAsync();
    }

    public Task<int> AddProduct(Product product)
    {
        if(product is null) throw new ArgumentNullException(nameof(product));
        _context.Products?.Add(product);
        return _context.SaveChangesAsync();
    }

    #endregion

    #region Delete InventoryItem | Order | OrderItem | Product
    public Task<int> DeleteInventoryItem(string id)
    {
        var item = _context.Inventory?.Find(id);
        if ( item is null)
            throw new KeyNotFoundException();

        _context.Remove(item);
        return _context.SaveChangesAsync();
    }

    public Task<int> DeleteOrder(int id)
    {
        var order = _context.Orders?.Find(id);
        if(order is null)
            throw new KeyNotFoundException();
        
        _context.Remove(order);
        return _context.SaveChangesAsync();
    }

    public Task<int> DeleteOrderItem(int id)
    {
        var orderItem = _context.OrderItems?.Find(id);
        if(orderItem is null)
            throw new KeyNotFoundException();
        
        _context.Remove(orderItem);
        return _context.SaveChangesAsync();
    }

    public Task<int> DeleteProduct(string id)
    {
        var product = (_context.Products?.Find(id)) ?? throw new KeyNotFoundException();      
        if(product is not null)  _context.Remove(product);
        
        return product is not null ? Task.FromResult(_context.SaveChanges()) :  Task.FromResult(0);
    }

    #endregion

    #region Get InventoryItem | Order | OrderItem | Products
    public InventoryItem GetInventoryItemById(string id)
    {
        return _context.Inventory?.Find(id) ?? new InventoryItem();
    }

    public IEnumerable<InventoryItem> GetInventoryItems()
    {
        return _context.Inventory?.ToList() ?? new List<InventoryItem>();
    }

    public Order GetOrderById(int id)
    {
        return _context.Orders?.Find(id) ?? new Order();
    }

    public OrderItem GetOrderItemById(int id)
    {
        return _context.OrderItems?.Find(id) ?? new OrderItem();
    }

    public IEnumerable<OrderItem> GetOrderItems()
    {
        return _context.OrderItems?.ToList() ?? new List<OrderItem>();
    }

    public IEnumerable<Order> GetOrders()
    {
        return _context.Orders?.ToList() ?? new List<Order>();
    }

    public Product GetProductById(string id)
    {
        return _context.Products?.Find(id) ?? new Product();
    }

    public IEnumerable<Product> GetProducts()
    {
        return _context.Products?.ToList() ?? new List<Product>();
    }

    #endregion

    #region Update InventoryItem | Order | OrderItem | Products
    public Task<int> UpdateInventoryItem(InventoryItem item)
    {
       var existingItem = _context.Inventory?.Find(item.Id);
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
        var existingOrder = _context.Orders?.Find(order.Id);
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
        var existingOrderItem = _context.OrderItems?.Find(orderItem.Id);

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
        var existingProduct = _context.Products?.Find(product.Id);
        if(existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.SKU = product.SKU;
            existingProduct.UpdatedAt = product.UpdatedAt;

            return Task.FromResult(_context.SaveChanges());
        }

        return Task.FromResult(0);
    }
    
    #endregion
}