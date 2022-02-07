using AutoMapper;
using RealEstate.API.DTOs;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Profiles
{
    public class PropertiesProfile : Profile
    {
        public PropertiesProfile()
        {
            CreateMap<Property, PropertyDto>()
                .ForMember(dest => dest.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name));
            CreateMap<PropertyForCreationDto, Property>()
                .ForMember(dest => dest.PropertyType, opt => opt.Ignore());
            CreateMap<PropertyForUpdateDto, Property>();
            CreateMap<Property, PropertyForUpdateDto>();
        }

    }
}
