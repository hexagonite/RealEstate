using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstate.API.Entities
{
    public class Address : BaseEntity
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string StateOrProvince { get; set; }
        public string City { get; set; }
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
        public int PropertyId { get; set; }
    }
}
