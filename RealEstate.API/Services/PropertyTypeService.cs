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
using Microsoft.Extensions.Caching.Memory;
using RealEstate.API.DTOs;

namespace RealEstate.API.Services
{
    public class PropertyTypeService : IPropertyTypeService
    {
        private const string PropertyTypeCacheKey = "PropertyTypes";

        private readonly IRealEstateContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public PropertyTypeService(IRealEstateContext dbContext, IMapper mapper, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<PropertyTypeDto>> GetAllPropertyTypes()
        {
            var propertyTypes = await GetPropertyTypeCache();
            return _mapper.Map<IEnumerable<PropertyTypeDto>>(propertyTypes);
        }

        public async Task<bool> PropertyTypeExists(string propertyTypeName)
        {
            var propertyTypes = await GetPropertyTypeCache();
            return propertyTypes.Any(x => x.Name == propertyTypeName);
        }

        public async Task<PropertyType> GetPropertyType(string propertyTypeName)
        {
            var propertyTypes = await GetPropertyTypeCache();
            return propertyTypes.FirstOrDefault(x => x.Name == propertyTypeName);
        }

        private async Task<IEnumerable<PropertyType>> GetPropertyTypeCache()
        {
            if (!_memoryCache.TryGetValue(PropertyTypeCacheKey, out IEnumerable<PropertyType> cachedPropertyTypes))
            {
                return await PopulatePropertyTypeCache();
            }
            return cachedPropertyTypes;
        }

        private async Task<IEnumerable<PropertyType>> PopulatePropertyTypeCache()
        {
            var propertyTypes = await _dbContext.PropertyTypes.ToListAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(8));
            _memoryCache.Set(PropertyTypeCacheKey, propertyTypes, cacheEntryOptions);

            return propertyTypes;
        }
    }
}
