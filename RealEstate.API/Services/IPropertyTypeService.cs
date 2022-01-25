using RealEstate.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.API.Services
{
    public interface IPropertyTypeService
    {
        Task<IEnumerable<PropertyType>> GetAllPropertyTypes();
    }
}
