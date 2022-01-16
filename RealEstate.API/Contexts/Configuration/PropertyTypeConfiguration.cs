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
                new PropertyType { Name = "Single Family Home" },
                new PropertyType { Name = "Multi Family Home" },
                new PropertyType { Name = "Townhome" },
                new PropertyType { Name = "Flat" },
                new PropertyType { Name = "Co-op" },
                new PropertyType { Name = "Condo" },
                new PropertyType { Name = "Mobile" },
                new PropertyType { Name = "Farm" },
                new PropertyType { Name = "Land" }
                );
        }
    }
}
