using System.ComponentModel.DataAnnotations;

namespace BusinessApi.Dtos;

public class ProductReadDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? SKU { get; set; }
    // public DateTime CreatedAt { get; set; }
    // public DateTime UpdatedAt { get; set; }
}

public class ProductCreateDTO
{
    [Required]
    public string? Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public string? SKU { get; set; }
    
    // public DateTime CreatedAt { get; set; }
    // public DateTime UpdatedAt { get; set; }
}