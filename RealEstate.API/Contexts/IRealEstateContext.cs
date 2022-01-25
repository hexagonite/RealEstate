using Microsoft.EntityFrameworkCore;
using RealEstate.API.Entities;
using System.Threading.Tasks;

namespace RealEstate.API.Contexts
{
    public interface IRealEstateContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Property> Properties { get; set; }
        DbSet<PropertyType> PropertyTypes { get; set; }

        Task SaveChangesAsync();
    }
}