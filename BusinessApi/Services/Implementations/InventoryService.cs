using System.Reflection.Metadata.Ecma335;
using BusinessApi.Data;
using BusinessApi.Dtos;
using BusinessApi.Interfaces;
using BusinessApi.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Product> AddProduct(Product product)
    {
        if(product is null) throw new ArgumentNullException(nameof(product));        
        
        var result = _context.Products.Add(product);
        await _context.SaveChangesAsync();      
        return result.Entity;
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
        var orderItem = (_context.OrderItems?.Find(id)) ?? throw new KeyNotFoundException();
        _context.Remove(orderItem);
        return _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteProduct(string id)
    {
        var product = await _context.Products.FindAsync(id) ?? throw new KeyNotFoundException();
        _context.Remove(product);
        await _context.SaveChangesAsync();
        return product is not null;
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

    public async Task<Product> GetProductById(string id) => await _context.Products.FindAsync(id);    

    public async Task<IEnumerable<Product>> GetProducts() => await _context.Products.ToListAsync();

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

    public async Task<Product> UpdateProduct(Product product)
    {
        try
        {
            var existingProduct =  _context.Products?.Find(product.Id);
            if(existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.SKU = product.SKU;
                existingProduct.UpdatedAt = product.UpdatedAt;

                var response = await _context.SaveChangesAsync();

                return existingProduct;                
            }
            else 
            {
                throw new KeyNotFoundException();                
            }            
        }   
        catch (DbUpdateConcurrencyException) 
        {
            throw;
        }                
    }
    
    #endregion
}