using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.API.Contexts;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Services
{
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly IRealEstateContext _dbContext;
        private readonly IMapper _mapper;

        public PropertyTypeService(IRealEstateContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyType>> GetAllPropertyTypes()
        {
            var propertyTypes = await _dbContext.PropertyTypes.ToListAsync();
            return _mapper.Map<IEnumerable<PropertyType>>(propertyTypes);
        }
    }
}
