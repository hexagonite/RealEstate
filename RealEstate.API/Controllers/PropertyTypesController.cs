using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.DTOs;
using RealEstate.API.Entities;
using RealEstate.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RealEstate.API.Controllers
{
    public class PropertyTypesController : BasicController
    {
        private readonly IPropertyTypeService _propertyTypeService;

        public PropertyTypesController(IPropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PropertyDto))]
        public async Task<ActionResult<IEnumerable<PropertyType>>> GetPropertyTypes()
        {
            var propertyTypes = await _propertyTypeService.GetAllPropertyTypes();
            return Ok(propertyTypes);
        }
    }
}
