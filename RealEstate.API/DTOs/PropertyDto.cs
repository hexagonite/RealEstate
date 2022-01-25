using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.DTOs
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int RoomAmount { get; set; }
        public decimal Size { get; set; }
        public DateTime UploadedAt { get; set; }
        public AddressDto Address { get; set; }
        public string PropertyType { get; set; }
    }
}
