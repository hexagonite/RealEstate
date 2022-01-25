using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Entities;
using RealEstate.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTypesController : ControllerBase
    {
        private readonly PropertyTypeService _propertyTypeService;

        public PropertyTypesController(PropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyType>>> GetPropertyTypes()
        {
            var propertyTypes = await _propertyTypeService.GetAllPropertyTypes();
            return Ok(propertyTypes);
        }
    }
}
