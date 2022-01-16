using RealEstate.API.Contexts;
using RealEstate.API.Entities;
using RealEstate.API.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstate.API.Repositories.Implementations
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(RealEstateContext context) : base(context)
        {
        }

    }
}
