using System.ComponentModel.DataAnnotations;

namespace BusinessApi.Dtos;

public class OrderDTO
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalPrice { get; set; }
    public int Status { get; set; }
}

public class OrderCreateDTO
{
    [Required]
    public string? CustomerName { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public double TotalPrice { get; set; }
    [Required]
    public int Status { get; set; }
}