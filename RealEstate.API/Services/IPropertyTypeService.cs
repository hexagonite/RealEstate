using RealEstate.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.API.DTOs;

namespace RealEstate.API.Services
{
    public interface IPropertyTypeService
    {
        Task<IEnumerable<PropertyTypeDto>> GetAllPropertyTypes();
        Task<bool> PropertyTypeExists(string propertyTypeName);
    }
}
