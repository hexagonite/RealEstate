using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAgency.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Username)
                .IsUnique();
            builder.HasIndex(u => u.EmailAddress)
                .IsUnique();
        }
    }
}
