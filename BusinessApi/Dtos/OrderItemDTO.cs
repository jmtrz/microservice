using System.ComponentModel.DataAnnotations;

namespace BusinessApi.Dtos;

public class OrderItemDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
}

public class OrderItemCreateDTO
{
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int Price { get; set; }
}