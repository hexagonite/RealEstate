using RealEstate.API.Contexts;
using RealEstate.API.Entities;
using RealEstate.API.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstate.API.Repositories.Implementations
{
    public class PropertyTypeRepository : GenericRepository<PropertyType>, IPropertyTypeRepository
    {
        public PropertyTypeRepository(RealEstateContext context) : base(context)
        {
        }

    }
}
