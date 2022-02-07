using RealEstate.API.DTOs;
using System.Threading.Tasks;

namespace RealEstate.API.Services
{
    public interface IAddressService
    {
        Task<bool> IsAddressUnique(AddressForManipulationDto addressDto);
    }
}