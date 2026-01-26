using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Infrastructure.configuration
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyEnumToStringConversions(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                var enumProperties = clrType.GetProperties().Where(p => p.PropertyType.IsEnum);
                foreach (var prop in enumProperties)
                {
                    var converterType = typeof(EnumToStringConverter<>).MakeGenericType(prop.PropertyType);
                    var converter = Activator.CreateInstance(converterType) as ValueConverter;
                    builder.Entity(clrType).Property(prop.Name).HasConversion(converter!);
                }
            }
        }
    }
}
