using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAgency.Infrastructure.Configuration
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasIndex(ut => ut.Name)
                .IsUnique();

            builder.HasData(
                new UserType { Name = "Admin" },
                new UserType { Name = "Moderator" },
                new UserType { Name = "User" }
            );
        }
    }
}
