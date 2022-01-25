using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.DTOs
{
    public abstract class PropertyForManipulationDto
    {
        [Range(1, 100)]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int RoomAmount { get; set; }
        public decimal Size { get; set; }
        public string PropertyType { get; set; }
    }
}
