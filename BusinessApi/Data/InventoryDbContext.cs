using BusinessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessApi.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> context) : base(context)
    {
        
    }

    public DbSet<Product>? ProductsContext { get; set; }
    public DbSet<OrderItem>? OrderItemsContext { get; set; }
    public DbSet<Order>? OrdersContext { get; set; }
    public DbSet<InventoryItem>? InventoryContext { get; set; }
}