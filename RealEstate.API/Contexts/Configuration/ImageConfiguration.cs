using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateAgency.Infrastructure.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            //builder.Entity<Image>()
            //    .HasOne(i => i.Property)
            //    .WithMany(p => p.Images)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
