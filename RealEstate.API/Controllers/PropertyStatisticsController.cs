using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.DTOs;
using RealEstate.API.Services;

namespace RealEstate.API.Controllers
{
    public class PropertyStatisticsController : BasicController
    {
        private readonly IPropertyStatisticsService _propertyStatisticsService;

        public PropertyStatisticsController(IPropertyStatisticsService propertyStatisticsService)
        {
            _propertyStatisticsService = propertyStatisticsService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PropertyDto))]
        public async Task<IActionResult> GetPropertyStatistics(PropertyStatisticsQueryDto propertyStatisticsQueryDto)
        {
            var propertyStatisticsDto = await _propertyStatisticsService.GetPropertyStatistics(propertyStatisticsQueryDto);

            return Ok(propertyStatisticsDto);
        }
    }
}
