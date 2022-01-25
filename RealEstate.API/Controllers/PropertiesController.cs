using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using RealEstate.API.DTOs;
using RealEstate.API.Entities;
using RealEstate.API.Services;
using System.Net;

namespace RealEstateAgency.API.Controllers
{
    [Route("api/properties")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        //[HttpGet]
        //[HttpHead]
        //public ActionResult<IEnumerable<PropertyDto>> GetProperties([FromQuery] PropertiesResourceParameters propertiesResourceParameters)
        //{
        //    var propertiesFromRepo = _propertyRepository.Find(propertiesResourceParameters);
        //    return Ok(_mapper.Map<IEnumerable<PropertyDto>>(propertiesFromRepo));
        //}

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

        //TODO: walidacja propertyType, mniej logiki w kontrolerze
        [HttpPost]
        public async Task<ActionResult<PropertyDto>> CreateProperty(PropertyForCreationDto propertyForCreationDto)
        {
            var propertyType = await _propertyService.CheckIfPropertyTypeExists(propertyForCreationDto.PropertyType);
            if (propertyType == null)
            {
                //TODO
                return BadRequest(new { message = $"{nameof(propertyForCreationDto.PropertyType)} {propertyForCreationDto.PropertyType} is invalid!" });
            }

            // TODO: validation - unique address
            //var addressExists = await _propertyService.CheckIfPropertyAddressIsUnique(property.Address);
            //if (addressExists)
            //{
            //    return BadRequest(new { message = $"There is already an existing property at the given address!" });
            //}

            var propertyToReturn = await _propertyService.CreateProperty(propertyForCreationDto, propertyType);
            return CreatedAtRoute("GetProperty",
                new { propertyId = propertyToReturn.Id },
                propertyToReturn);
        }

    }
}
