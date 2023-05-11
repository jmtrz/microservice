namespace BusinessApi.Models ;

public class Order
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalPrice { get; set; }
    public int Status { get; set; }
}