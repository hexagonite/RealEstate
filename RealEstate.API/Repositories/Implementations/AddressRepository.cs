using RealEstate.API.Contexts;
using RealEstate.API.Entities;
using RealEstate.API.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.API.Repositories.Implementations
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(RealEstateContext context) : base(context)
        {
        }
    }
}
