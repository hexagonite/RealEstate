using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAgency.Infrastructure.Configuration
{
    public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.HasIndex(pt => pt.Name)
                .IsUnique();

            builder.HasData(
                new PropertyType { Id = 1, Name = "Single Family Home" },
                new PropertyType { Id = 2, Name = "Multi Family Home" },
                new PropertyType { Id = 3, Name = "Townhome" },
                new PropertyType { Id = 4, Name = "Flat" },
                new PropertyType { Id = 5, Name = "Co-op" },
                new PropertyType { Id = 6, Name = "Condo" },
                new PropertyType { Id = 7, Name = "Mobile" },
                new PropertyType { Id = 8, Name = "Farm" },
                new PropertyType { Id = 9, Name = "Land" }
                );
        }
    }
}
