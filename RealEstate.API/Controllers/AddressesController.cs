using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.DTOs;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.API.Controllers
{
    [Route("api/properties/{propertyId}/address")]
    [ApiController]
    public class AddressesController : ControllerBase
    {

        public AddressesController()
        {
        }

        //[HttpGet]
        //public ActionResult<AddressDto> GetAddressForProperty(int propertyId)
        //{
        //    var property = _propertyRepository.GetById(propertyId);
        //    if (property == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<AddressDto>(property.Address));
        //}

    }
}
