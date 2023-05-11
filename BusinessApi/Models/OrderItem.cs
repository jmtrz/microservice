namespace BusinessApi.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    // public int MyProperty { get; set; }
    // public int MyProperty { get; set; }
}