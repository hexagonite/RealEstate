using AutoMapper;
using RealEstate.API.DTOs;
using RealEstate.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Profiles
{
    public class PropertyTypesProfile : Profile
    {
        public PropertyTypesProfile()
        {
            CreateMap<string, PropertyType>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src));
            CreateMap<PropertyType, PropertyTypeDto>();
        }
    }
}
