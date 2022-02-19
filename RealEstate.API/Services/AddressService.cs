using Microsoft.EntityFrameworkCore;
using RealEstate.API.Contexts;
using RealEstate.API.DTOs;
using System.Threading.Tasks;

namespace RealEstate.API.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRealEstateContext _dbContext;

        public AddressService(IRealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsAddressUnique(AddressForManipulationDto addressDto)
        {
            return await _dbContext.Addresses.AnyAsync(a => 
                a.AddressLine1 == addressDto.AddressLine1 && 
                a.AddressLine2 == addressDto.AddressLine2 && 
                a.PostalCode == addressDto.PostalCode && 
                a.StateOrProvince == addressDto.StateOrProvince && 
                a.City == addressDto.City
                );
        }
    }
}
