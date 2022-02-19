using System.Threading.Tasks;
using RealEstate.API.DTOs;

namespace RealEstate.API.Services
{
    public interface IPropertyStatisticsService
    {
        Task<PropertyStatisticsDto> GetPropertyStatistics(PropertyStatisticsQueryDto propertyStatisticsQueryDto);
    }
}
