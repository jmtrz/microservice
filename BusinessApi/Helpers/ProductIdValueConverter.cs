
using BusinessApi.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusinessApi.Helpers;

[EfCoreValueConverter(typeof(ProductIdValueConverter))]
public readonly struct ProductId : IComparable<ProductId>, IEquatable<ProductId>
{
    public Guid Value { get; }
    public ProductId(Guid value)
    {
        Value = value;
    }

    public class ProductIdValueConverter : ValueConverter<ProductId, Guid>
    {
        public ProductIdValueConverter(ConverterMappingHints? mappingHints = null) 
            : base(
                id => id.Value, 
                value => new ProductId(value), 
                mappingHints
            ) { }
    }

    public int CompareTo(ProductId other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(ProductId other)
    {
        throw new NotImplementedException();
    }
}


