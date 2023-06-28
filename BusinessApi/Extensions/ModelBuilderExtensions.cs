
using System.Reflection;
using BusinessApi.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusinessApi.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder UseValueConverter(this ModelBuilder modelBuilder, ValueConverter converter)
    {
        //The Strongly Typed ID Type
        var type = converter.ModelClrType;

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            //Find the properties that are stronly-typed ID
            var properties = entityType
                                .ClrType
                                .GetProperties()
                                .Where(p => p.PropertyType == type);

            foreach (var property in properties)
            {
                //Use the vaue converter for the property
                modelBuilder
                    .Entity(entityType.Name)
                    .Property(property.Name)
                    .HasConversion(converter);
            }
        }

        return modelBuilder;
    }

    public static ModelBuilder AddStronglyTypedIdValueConverters<T>(this ModelBuilder modelBuilder)
    {
        var assembly = typeof(T).Assembly;
        foreach(var type in assembly.GetTypes())
        {
            var attribute = type
                .GetCustomAttributes<EfCoreValueConverterAttribute>()
                .FirstOrDefault();
            
            if(attribute is null) continue;

            // The ValueConverter must have a parameterless constructor
            var converter = Activator.CreateInstance(attribute.ValueConverter) as ValueConverter;

            modelBuilder.UseValueConverter(converter);
        }

        return modelBuilder;

    }
}