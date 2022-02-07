using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.DTOs;
using RealEstate.API.Services;

namespace RealEstate.API.Controllers
{
    public class PropertiesController : BasicController
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet("{propertyId}", Name = "GetProperty")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PropertyDto))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProperty(int propertyId)
        {
            var propertyDto = await _propertyService.GetProperty(propertyId);

            if (propertyDto == null)
            {
                return NotFound();
            }

            return Ok(propertyDto);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(PropertyDto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<PropertyDto>> CreateProperty(PropertyForCreationDto propertyForCreationDto)
        {
            var propertyToReturn = await _propertyService.CreateProperty(propertyForCreationDto);
            return CreatedAtRoute("GetProperty",
                new { propertyId = propertyToReturn.Id },
                propertyToReturn);
        }

    }
}
