using BusinessApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessApi.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> context) : base(context)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<InventoryItem>? Inventory { get; set; }

    //using fluent API
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);

    //     //Registering the custom ValueConverter with EF Core's DB context
    //     // modelBuilder
    //     //     .Entity<Product>()
    //     //     .Property(p => p.Id)
    //     //     .HasConversion(new ProductIdValueConverter());        

    //     /*
    //         Automatically using a value converter for all properties of a given type
    //         UseValueConvert and ProductIdValuConverter
    //     */
    //     // modelBuilder.UseValueConverter(new ProductIdValueConverter());
    //     modelBuilder.AddStronglyTypedIdValueConverters<Helpers.ProductId>();

    // }
}