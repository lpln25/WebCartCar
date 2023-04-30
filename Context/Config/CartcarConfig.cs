using CartCar.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartCar.App.Context.Config
{
    public class CartcarConfig : IEntityTypeConfiguration<Cartcar>
    {
        public void Configure(EntityTypeBuilder<Cartcar> builder)
        {
            var enumToStringCharacterTag = new ValueConverter<Specialcharacters, string>(p => p.ToString()
            , p => (Specialcharacters)Enum.Parse(typeof(Specialcharacters), p));

            var enumToStringFuel = new ValueConverter<SpecialFuelType, string>(p => p.ToString()
            , p => (SpecialFuelType)Enum.Parse(typeof(SpecialFuelType), p));

            builder.Property(p => p.FuelType).HasConversion(enumToStringFuel);
            builder.Property(p => p.Part1).HasMaxLength(2);
            builder.Property(p => p.Part2).HasConversion(enumToStringCharacterTag);
            builder.Property(p => p.Part3).HasMaxLength(3);
            builder.Property(p => p.Part4).HasMaxLength(2);
            builder.Ignore(p => p.Specialcharacters);
            builder.Ignore(p => p.SpecialFuelTypes);

        }
    }
}
