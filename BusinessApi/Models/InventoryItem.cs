using System.ComponentModel.DataAnnotations;

namespace BusinessApi.Models;

public class InventoryItem 
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int Location { get; set; }
}