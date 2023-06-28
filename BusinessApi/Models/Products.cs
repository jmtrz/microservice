using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StronglyTypedIds;

namespace BusinessApi.Models;


// [StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)]
// public partial struct ProductId { }

public class Product 
{    
    public string? Id { get; set; } 
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? SKU { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}