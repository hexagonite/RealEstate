using Microsoft.EntityFrameworkCore;
using RealEstate.API.Entities;
using RealEstateAgency.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Contexts
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options)
        {
            Database.EnsureCreated(); // remove if using migrations
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressConfiguration());
            //builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new PropertyConfiguration());
            builder.ApplyConfiguration(new PropertyTypeConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserTypeConfiguration());
        }
        public DbSet<Address> Addresses { get; set; }
        //public DbSet<Address> Images { get; set; }
        public DbSet<Address> Properties { get; set; }
        public DbSet<Address> PropertyTypes { get; set; }
        public DbSet<Address> Users { get; set; }
        public DbSet<Address> UserTypes { get; set; }
    }
}
