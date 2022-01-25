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
        private readonly IRealEstateContext _dbContext;
        private readonly IMapper _mapper;

        public PropertyService(IRealEstateContext dbContext, IMapper mapper)
        {
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

        public Task<PropertyType> CheckIfPropertyTypeExists(string propertyTypeName)
        {
            // AnyAsync
            // move to propertytypeservice
            return _dbContext.PropertyTypes.FirstOrDefaultAsync(p => p.Name == propertyTypeName);
        }

        public async Task<bool> CheckIfPropertyAddressIsUnique(AddressForCreationDto addressForCreationDto)
        {
            throw new NotImplementedException();
            //var addressFromRepo = await _dbContext.Set<Address>().FirstOrDefaultAsync(/*predicate*/);
            //if (addressFromRepo == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        public async Task<PropertyDto> CreateProperty(PropertyForCreationDto propertyForCreationDto, PropertyType propertyType)
        {
            //map and validate property type
            //map and validate address (uniqueness)
            /////insert address and property into db
            /////save changes
            /////map property to propertyDto

            var propertyEntity = _mapper.Map<Property>(propertyForCreationDto);
            propertyEntity.PropertyType = propertyType;
            propertyEntity.UploadedAt = DateTime.Now;
            
            _dbContext.Properties.Add(propertyEntity);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PropertyDto>(propertyEntity);
        }

    }
}
