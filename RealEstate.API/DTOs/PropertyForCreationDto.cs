using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.DTOs
{
    public class PropertyForCreationDto : PropertyForManipulationDto
    {
        public AddressForCreationDto Address { get; set; }
    }
}
