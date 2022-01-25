using Microsoft.EntityFrameworkCore;
using RealEstate.API.Entities;
using RealEstateAgency.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Contexts
{
    public class RealEstateContext : DbContext, IRealEstateContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressConfiguration());
            //builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new PropertyConfiguration());
            builder.ApplyConfiguration(new PropertyTypeConfiguration());
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public DbSet<Address> Addresses { get; set; }
        //public DbSet<Address> Images { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
    }
}
