using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.API.Contexts;
using RealEstate.API.DTOs;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyTypeService _propertyTypeService;
        private readonly IRealEstateContext _dbContext;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyTypeService propertyTypeService, IRealEstateContext dbContext, IMapper mapper)
        {
            _propertyTypeService = propertyTypeService;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PropertyDto> GetProperty(int propertyId)
        {
            var propertyFromRepo = await _dbContext.Properties
                .Include(p => p.Address)
                .Include(p => p.PropertyType)
                .FirstOrDefaultAsync(p => p.Id == propertyId);

            return _mapper.Map<PropertyDto>(propertyFromRepo);
        }

        public async Task<PropertyDto> CreateProperty(PropertyForCreationDto propertyForCreationDto)
        {
            var propertyEntity = _mapper.Map<Property>(propertyForCreationDto);
            var propertyType = await _propertyTypeService.GetPropertyType(propertyForCreationDto.PropertyType);
            propertyEntity.PropertyType = propertyType;
            propertyEntity.UploadedAt = DateTime.UtcNow;

            _dbContext.Properties.Add(propertyEntity);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PropertyDto>(propertyEntity);
        }

    }
}
