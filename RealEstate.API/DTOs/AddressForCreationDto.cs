using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.DTOs
{
    public class AddressForCreationDto
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string StateOrProvince { get; set; }
        public string City { get; set; }
    }
}
