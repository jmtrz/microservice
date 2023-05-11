using System.ComponentModel.DataAnnotations;

namespace BusinessApi.Dtos;

public class InventoryDTO
{
    public int Id { get; set; }    
    public int ProductId { get; set; }    
    public int Quantity { get; set; }    
    public int Location { get; set; }
}

public class InventoryCreateDTO
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int Location { get; set; }
}