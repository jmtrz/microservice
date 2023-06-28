using AutoMapper.Execution;

namespace BusinessApi.Helpers;

[AttributeUsage(AttributeTargets.All)]
public class EfCoreValueConverterAttribute : Attribute
{    
    public EfCoreValueConverterAttribute(Type valueConverter)
    {
        ValueConverter = valueConverter;
    }   

    public Type ValueConverter { get; } 
}