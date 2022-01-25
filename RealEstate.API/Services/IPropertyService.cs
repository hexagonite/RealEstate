using RealEstate.API.DTOs;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Services
{
    public interface IPropertyService
    {
        Task<PropertyDto> GetProperty(int propertyId);
        Task<PropertyType> CheckIfPropertyTypeExists(string propertyTypeName);
        Task<bool> CheckIfPropertyAddressIsUnique(AddressForCreationDto address);
        Task<PropertyDto> CreateProperty(PropertyForCreationDto propertyForCreationDto, PropertyType propertyType);
    }
}
