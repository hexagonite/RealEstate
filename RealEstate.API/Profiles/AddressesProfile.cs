using AutoMapper;
using RealEstate.API.DTOs;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Profiles
{
    public class AddressesProfile : Profile
    {
        public AddressesProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<AddressForCreationDto, Address>();
            CreateMap<AddressForUpdateDto, Address>();
        }
    }
}
