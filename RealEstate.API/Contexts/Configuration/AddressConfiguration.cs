using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAgency.Infrastructure.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasIndex(p => new { p.AddressLine1, p.AddressLine2, p.PostalCode, p.StateOrProvince, p.City })
                .IsUnique();
        }
    }
}
